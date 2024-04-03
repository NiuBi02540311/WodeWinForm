using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Index());
            //return;
            Login login = new Login();
            DialogResult Result  = login.ShowDialog();
            //if (formLogin.ShowDialog() == DialogResult.OK)
            if (Result.Equals(DialogResult.OK))
            {
                
                Application.Run(new Index());
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main222(string[] args)
        {
            //这里的 string[] arrgs 原本是没有的，我这里加上后，另外加上密码，
            //直接双击exe 文件是打不开的，这里代码的主要作用也是如此
            if (args.Length == 0)
                return;
            if (args[0] != "密码")
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Index());
        }
 
    }
}
