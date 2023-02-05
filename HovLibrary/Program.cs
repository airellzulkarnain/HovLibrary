using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login_section:
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            if (loginForm.DialogResult == DialogResult.OK)
            {
                MainForm mainForm = new MainForm(loginForm.employee_id);
                loginForm.Dispose();
                Application.Run(mainForm);
                mainForm.Dispose();
                goto login_section;
            }
        }
    }
}
