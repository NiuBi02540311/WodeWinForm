using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm
{
    public static class GlobalConfig
    {
        public static Color BackColor = Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
        public static Color BackColor2 = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));

        //public static Color BackColor2 = Color.FromArgb(0, 140, 190, 190);
        // 80, 160, 255
        public static string LocalHostIP = GetIP();

        public static int LoginUserID = 0;

        public static string LoginUserName = "";

        public static string LoginUserPassword = "";

        public static ImageList imageList = LoadimageList();

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

        private static ImageList LoadimageList()
        {
            ImageList imageList = null;
            string imagedirPath = @"E:\2024\WodeWinForm\WodeWinForm\Lib\1";
            if (Directory.Exists(imagedirPath))
            {
                string[] stringsPath = Directory.GetFiles(imagedirPath, "*.png");
                if (stringsPath.Length > 0)
                {
                    imageList = new ImageList();
                    string[] fileType = { ".jpg", ".png", ".ico" };

                    var list = stringsPath.ToList().OrderBy(x => x);
                    foreach (string s in list)
                    {
                        if (fileType.Contains(Path.GetExtension(s)))
                        {
                            Image image = Image.FromFile(s);
                            string keyName = Path.GetFileNameWithoutExtension(s);
                            imageList.Images.Add(keyName, image);
                        }
                    }
                    imageList.ImageSize = new Size(16, 16);
                    imageList.TransparentColor = Color.Transparent;
                    //使用imageList
                    //label1.ImageList = imageList1;
                    //label1.ImageKey = "1";
                    //button1.ImageList = imageList1;
                    //button1.ImageIndex = 2;

                    
                }

            }
           return imageList;
        }

    }


}
