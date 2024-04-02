using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm.View
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //var BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            //this.BackColor = BackColor;
            this.Load += Form1_Load;
        }
        private class FileType
        {
            /// <summary>
            /// 路径
            /// </summary>
            public string Path { get; set; }
            /// <summary>
            /// 哈希值
            /// </summary>
            public string Hashs { get; set; }
        }
        private class UpdateFile
        {
            /// <summary>
            /// 文件夹列表
            /// </summary>
            public List<string> DirectoryList { get; set; } = new List<string>();
            /// <summary>
            /// 文件列表
            /// </summary>
            public List<FileType> FilesinfoList { get; set; } = new List<FileType>();
            /// <summary>
            /// 服务器版本号
            /// </summary>
            public string Version { get; set; }
        }
        //需要生成列表的目录
        //private string Path = "D:\\H\\本地服务器工具\\Software\\News\\";
        private string Path = @"E:\2024\WodeWinForm\Software\News";
        //存放json的位置
        private string FileConfigJsonPath = @"E:\2024\WodeWinForm\Software\FileList.json";

        //本地文件的黑名单（不参与到更新）
        private static List<string> LocalFileBlacklist = new List<string>();

        //文件夹列表
        private static List<string> DirectorysList = new List<string>();
        //文件列表
        private static List<FileType> FilesinfoList = new List<FileType>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TextBox_Path.Text = Path;

            //添加黑名单
            LocalFileBlacklist.Add("log4net.dll");
            LocalFileBlacklist.Add("log4net.xml");
            LocalFileBlacklist.Add("Newtonsoft.Json.dll");
            LocalFileBlacklist.Add("Newtonsoft.Json.xml");


            //string localVersionPath = FileVersionInfo.GetVersionInfo(Path + "\\Test1.exe").FileVersion;
            string localVersionPath = "1.23";
            Console.WriteLine("软件的版本号" + localVersionPath);
        }

       
 
        private void button1_Click(object sender, EventArgs e)
        {
            Button_SelectionPath_Click();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button_CreaterFile_Click();
        }
        /// <summary>
        /// 选择路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SelectionPath_Click()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            dialog.SelectedPath = Path;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                Path = dialog.SelectedPath;
                this.TextBox_Path.Text = Path;
            }
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CreaterFile_Click()
        {
            DirectorysList.Clear();
            FilesinfoList.Clear();

            if (System.IO.Directory.Exists(Path))
            {
                Task.Run(() =>
                {
                    GetDirectoryFileList(Path);

                    if (FilesinfoList.Count > 0)
                    {
                        UpdateFile updateFile = new UpdateFile();
                        updateFile.DirectoryList = DirectorysList;
                        updateFile.FilesinfoList = FilesinfoList;
                        //updateFile.Version = FileVersionInfo.GetVersionInfo(Path + "\\Test1.exe").FileVersion;
                        updateFile.Version = "1.10";

                        //生成json文件
                        string json = JsonConvert.SerializeObject(updateFile);
                        //加密json文件
                        //json = Utils.DES.EncryptDes(json, Utils.DESKey.Key, Utils.DESKey.IV);
                        WriteJsonFile(FileConfigJsonPath, json);
                        MessageBox.Show("生成文件成功！");
                    }
                });
            }
        }


        /// <summary>
        /// 获取一个文件夹下的所有文件和文件夹集合
        /// </summary>
        /// <param name="path"></param>
        private void GetDirectoryFileList(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] filesArray = directory.GetFileSystemInfos();
            foreach (var item in filesArray)
            {
                if (item.Attributes == FileAttributes.Directory)
                {
                    //添加文件夹
                    string dir = item.FullName.Replace(Path, "");
                    DirectorysList.Add(dir);
                    GetDirectoryFileList(item.FullName);
                }
                else
                {
                    string fileName = item.FullName.Replace(Path, "");
                    fileName = fileName.Replace(@"\", @"/");

                    //是否在黑名单中
                    bool isBlackList = false;
                    if (LocalFileBlacklist.Count > 0)
                    {
                        for (int i = 0; i < LocalFileBlacklist.Count; i++)
                        {
                            if (LocalFileBlacklist[i].Equals(fileName))
                            {
                                isBlackList = true;
                                break;
                            }
                        }
                    }
                    if (!isBlackList)
                    {
                        //添加文件
                        FileType fileType = new FileType();
                        fileType.Path = fileName;
                        fileType.Hashs = GetHashs(item.FullName);
                        FilesinfoList.Add(fileType);
                    }
                }
            }
        }

        /// <summary>
        /// 获取文件的哈希值
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetHashs(string path)
        {
            //创建一个哈希算法对象
            using (HashAlgorithm hash = HashAlgorithm.Create())
            {
                using (FileStream file1 = new FileStream(path, FileMode.Open))
                {
                    //哈希算法根据文本得到哈希码的字节数组
                    byte[] hashByte1 = hash.ComputeHash(file1);
                    //将字节数组装换为字符串
                    return BitConverter.ToString(hashByte1);
                }
            }
        }

        /// <summary>
        /// 将json字符串内容写入Json文件并保存（若json文件不存在则创建）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="jsonConents">Json内容</param>
        private void WriteJsonFile(string path, string jsonConents)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }
        }

       
    }
}
