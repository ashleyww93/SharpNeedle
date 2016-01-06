using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpDomain
{
    public interface IAssemblyLoader
    {
        void LoadAndRun(string file, string args);
    }

    public class Startup
    {
        /// <summary>
        /// The hotkey that can be pressed to re-inject your assembly
        /// </summary>
        private const Keys ReloadHotKey = Keys.F11;

        [STAThread]
        public static int EntryPoint(string filePath, string args = "")
        {
            bool firstLoaded = false;
            while (true) //Keep the domain alive to enable reloading, this will hang while the choose assembly is running
            {
                if (!firstLoaded)
                {
                    firstLoaded = true;
                    new SharpDomain(filePath, args);
                }

                if ((GetAsyncKeyState((int)ReloadHotKey) & 1) == 1)
                {
                    new SharpDomain(filePath, args);
                }

                Thread.Sleep(10);
            }
            return 0;
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
    }

    public static class DomainManager
    {
        public static AppDomain CurrentDomain { get; set; }
        public static WSharpAssemblyLoader CurrentAssemblyLoader { get; set; }
    }

    public class WSharpAssemblyLoader : MarshalByRefObject, IAssemblyLoader
    {
        public WSharpAssemblyLoader()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        #region IAssemblyLoader Members

        public void LoadAndRun(string file, string args)
        {
            Assembly asm = Assembly.Load(file);

            var STAMethods = asm.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(STAThreadAttribute), false).Length > 0)
                      .ToArray();


            if (STAMethods.Count() != 1)
            {
                if (!STAMethods.Any())
                {
                    SharpLoader.ShowError(new Exception("Unable to find entry function with [STAThread] Attribute"));
                    //MessageBox.Show("Unable to find entry function with [STAThread] Attribute");
                    return;
                }
                SharpLoader.ShowError(new Exception("More than one function with an [STAThread] Attribute was found; injected dlls should only have one"));
               // MessageBox.Show("More than one function with an [STAThread] Attribute was found; injected dlls should only have one");
                    return;
            }

            var entry2 = STAMethods[0];
            if (entry2 == null)
            {
                SharpLoader.ShowError(new Exception(string.Format("[STAThread] Attribute for {0} not found", file)));
               // MessageBox.Show("Entry of " + file + " not found.");
            }

            if (string.IsNullOrEmpty(args))
                entry2.Invoke(null, null);
            else
                entry2.Invoke(null, new[] {args});
        }

        #endregion

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == Assembly.GetExecutingAssembly().FullName)
                return Assembly.GetExecutingAssembly();

            string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string shortAsmName = Path.GetFileName(args.Name);
            string fileName = Path.Combine(appDir, shortAsmName);

            if (File.Exists(fileName))
            {
                return Assembly.LoadFrom(fileName);
            }
            return Assembly.GetExecutingAssembly().FullName == args.Name ? Assembly.GetExecutingAssembly() : null;
        }
    }

    /// <summary> 
    /// The actual domain object we'll be using to load and run the Dysis binaries.
    /// </summary>
    public class SharpDomain
    {
        private readonly Random _rand = new Random();
        public SharpDomain(string assemblyName, string args)
        {
            try
            {
                string appBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var ads = new AppDomainSetup
                {
                    ApplicationBase = appBase,
                    PrivateBinPath = appBase
                };
                DomainManager.CurrentDomain = AppDomain.CreateDomain("SharpDomain_Internal_" + _rand.Next(0, 100000), AppDomain.CurrentDomain.Evidence, ads);

                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

                DomainManager.CurrentAssemblyLoader =
                    (WSharpAssemblyLoader) DomainManager.CurrentDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                                                               typeof(WSharpAssemblyLoader).FullName);

                string fileToLoadAndRun = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),assemblyName);
                DomainManager.CurrentAssemblyLoader.LoadAndRun(fileToLoadAndRun, args);
            }
            catch (Exception e)
            {
                SharpLoader.ShowError(e);
               // MessageBox.Show(e.ToString());
            }
            finally
            {
                DomainManager.CurrentAssemblyLoader = null;
                AppDomain.Unload(DomainManager.CurrentDomain);
            }
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                if (args.Name == Assembly.GetExecutingAssembly().FullName)
                    return Assembly.GetExecutingAssembly();

                Assembly assembly = System.Reflection.Assembly.Load(args.Name);
                if (assembly != null)
                    return assembly;
            }
            catch
            {
                // ignore load error 
            }


            // *** NOTE: this doesn't account for special search paths
            string[] Parts = args.Name.Split(',');
            string File = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Parts[0].Trim() + ".dll";

            return System.Reflection.Assembly.LoadFrom(File);
        }
    }
}
