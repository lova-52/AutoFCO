using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace AutoFCO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Check if running as administrator
            if (!IsRunningAsAdmin())
            {
                MessageBox.Show("This application needs to be run as administrator.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            Application.Run(form);
        }

        public static bool IsRunningAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
