using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using RGiesecke.DllExport;

namespace SharpDomain
{
    public static class SharpLoader
    {
        #region Fields, Private Properties
        /// <summary>
        ///     The arguements for the hosted application
        /// </summary>
        internal static string ApplicationArguments = string.Empty;

        /// <summary>
        ///     The application to be hosted name.
        /// </summary>
        internal static string ApplicationToHostName = string.Empty;

        /// <summary>
        ///     The application path to be hosted. Must contain the ending '\' slash.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        internal static string ApplicationToHostDirectory = string.Empty;
        #endregion

        /// <summary>
        ///     Hosts the given domain.
        /// </summary>
        [DllExport]
        [STAThread]
        public static void HostDomain()
        {
            if (string.IsNullOrEmpty(ApplicationToHostName) || string.IsNullOrEmpty(ApplicationToHostDirectory))
            {
                throw new InvalidDataException("You must set LoadDomainHostSettings before calling HostDomain()");
                return;
            }

            try
            {
                if (ApplicationToHostName.EndsWith("exe") || ApplicationToHostName.EndsWith("dll"))
                {
                    Startup.EntryPoint(Path.Combine(ApplicationToHostDirectory, ApplicationToHostName), ApplicationArguments);
                }
                else
                {
                    MessageBox.Show("Invalid file type, SharpDomain can only load exe/dll files");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        ///     Loads the domain host settings. Call this with the desired params before calling <see cref="HostDomain()" />.
        /// </summary>
        /// <param name="loadDirectory">The directory the domain is contained in,</param>
        /// <param name="applicationName">Name of the application.</param>
        [DllExport("LoadDomainHostSettings", CallingConvention.Cdecl)]
        public static void LoadDomainHostSettings(string loadDirectory, string applicationName, string applicationArguments)
        {
            ApplicationToHostDirectory = loadDirectory;
            ApplicationToHostName = applicationName;
            ApplicationArguments = applicationArguments;
        }

        internal static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "SharpDomain Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
