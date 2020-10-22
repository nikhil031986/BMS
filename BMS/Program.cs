using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
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
            frmLogin winfStartLogin = new frmLogin();
            winfStartLogin.ShowDialog();
            if (DataUtil.currentUserInfo.User_Name != string.Empty)
            {
                Application.Run(new frmMdiBMS());
            }

        }
    }
}
