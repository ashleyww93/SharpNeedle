using System;
using System.Windows.Forms;

namespace SharpPayload
{
    public class Main
    {
        /// <summary>
        /// The main entry point for the application.
        /// Unlike C++, C# does not have the ability to specify an EntryPoint. Therefore SharpDomain looks for a [STAThread] Attribute and uses that as an EntryPoint
        /// </summary>
        [STAThread]
        public static int Run(string arg)
        {
            MessageBox.Show("C#/.Net dll payload example");
            MessageBox.Show(arg.ToString());
            return 0;
        }


        public static void Terminate()
        {

        }
    }
}
