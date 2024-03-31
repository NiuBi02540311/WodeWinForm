using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WodeWinForm
{
    public static class GlobalConfig
    {
        public static Color BackColor = Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
        //public static Color BackColor2 = Color.FromArgb(0, 140, 190, 190);

        public static string LocalHostIP = GetIP();

        public static int LoginUserID = 0;

        public static string LoginUserName = "";

        public static string LoginUserPassword = "";

        private static string GetIP(){

            var hostName = Dns.GetHostName();
            var ipAddresses = Dns.GetHostAddresses(hostName);
            foreach (var ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    var localIp = ipAddress.ToString();
                    Console.WriteLine(localIp);
                    return localIp;
                }
            }
            return "";
        }

    }


}
