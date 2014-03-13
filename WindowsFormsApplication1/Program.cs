using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace CarBus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin fLogin = new frmLogin();
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
                else
                {
                    Application.Exit();
                }
            
            

            //Application.Run(new frmLogin());
            
        }
    }
}
