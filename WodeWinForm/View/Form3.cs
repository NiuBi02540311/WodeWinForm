using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WodeWinForm.View
{
    public partial class Form3 : Form
    {
        string url = " http://XXX(服务器地址)/update/pcapp/"; //这里改为你的WebService地址。
        string fUpdate = @"";
        string AppName = "BarcodePrint";
        string m_workPath = "";
        string xmlFile = null;
        public Form3()
        {
            InitializeComponent();
            //m_workPath = Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(0, Assembly.GetExecutingAssembly().GetName().CodeBase.LastIndexOf(@"/") + 1).Replace(@"file:///", "");


            //Release版本
            //m_workPath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //m_workPath = System.IO.Path.GetDirectoryName(m_workPath);
            m_workPath = AppDomain.CurrentDomain.BaseDirectory;
            //m_workPath = Application.StartupPath;
            //xmlFile = m_workPath;
 
            //MessageBox.Show(m_workPath);
            //string workPath = System.IO.Path.Combine(filePath, "Config.xml");
 
            //DataSet ds = new DataSet();
            //ds.ReadXml( m_workPath + "config.xml");
            //url = ds.Tables[0].Rows[0]["WebServiceURL"].ToString();
            //url = url.Substring(0, url.IndexOf("Service"));
            //url += "update/Update_TKE_HT/";
            //AppName = ds.Tables[0].Rows[0]["AppName"].ToString();
 
        }
        private void Download()
        {
            //获取本地应用程序目录
            DirectoryInfo theFolder = new DirectoryInfo(Path.GetDirectoryName(this.m_workPath + "\\"));
            //获取服务器目录
            //DirectoryInfo theFolder = new DirectoryInfo(fUpdate);

            try
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.Refresh();

                foreach (FileInfo theFile in theFolder.GetFiles())
                {
                    DownloadFile(theFile.Name, url + theFile.Name);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.button1.Enabled = true;
                this.button2.Enabled = true;
            }
            //启动程序 
            System.Diagnostics.Process.Start(this.m_workPath + "\\" + AppName + ".exe", "");
            Application.Exit();
            Close();

        }
        private void DownloadFile(string FileName, string strUrl)
        {
            HttpWebRequest request;
            HttpWebResponse response = null;
            try
            {
                System.Globalization.DateTimeFormatInfo dfi = null;
                System.Globalization.CultureInfo ci = null;
                ci = new System.Globalization.CultureInfo("zh-CN");
                dfi = new System.Globalization.DateTimeFormatInfo();

                //WebRequest wr = WebRequest.Create("");

                //System.Net.WebResponse w=wr.
                DateTime fileDate;
                long totalBytes;
                DirectoryInfo theFolder = new DirectoryInfo(Path.GetTempPath() + "");
                string fileName = theFolder + FileName;

                fileName = @"E:\2024\WodeWinForm\DownloadFile\" + FileName;
           

            request = (HttpWebRequest)HttpWebRequest.Create(strUrl);

                response = (HttpWebResponse)request.GetResponse();

                if (response == null)
                    return;
                fileDate = response.LastModified;
                //if (File.GetLastWriteTime(m_workPath+"\\"+FileName) >= fileDate)
                //{
                //    response.Close();
                //    return;
                //}
                totalBytes = response.ContentLength;
                progressBar1.Maximum = Convert.ToInt32(totalBytes);
                progressBar1.Maximum = 100;
                uiProcessBar1.Maximum = 100;
                int total = Convert.ToInt32(totalBytes);
                Stream stream = response.GetResponseStream();
                FileStream sw = new FileStream(fileName, FileMode.Create);
                int totalDownloadedByte = 0;
                Byte[] @by = new byte[1024];
                int osize = stream.Read(@by, 0, @by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    sw.Write(@by, 0, osize);
                    // progressBar1.Value = totalDownloadedByte;
                    //progressBar1.Value = (totalDownloadedByte / total ) * 100;
                    uiProcessBar1.Value = (totalDownloadedByte / total) * 100;
                    osize = stream.Read(@by, 0, @by.Length);
                }
                sw.Close();
                stream.Close();

                //System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(AppName);

                //闭原有应用程序的所有进程
                //foreach (System.Diagnostics.Process pro in proc)
                //{
                //    pro.Kill();
                //}


                //DirectoryInfo theFolder = new DirectoryInfo(Path.GetTempPath() + "ysy");
                if (theFolder.Exists)
                {
                    foreach (FileInfo theFile in theFolder.GetFiles())
                    {
                        //如果临时文件夹下存在与应用程序所在目录下的文件同名的文件，则删除应用程序目录下的文件 
                        if (File.Exists(this.m_workPath + "\\" + Path.GetFileName(theFile.FullName)))
                        {
                            File.Delete(this.m_workPath + "\\" + Path.GetFileName(theFile.FullName));
                            //将临时文件夹的文件移到应用程序所在的目录下 
                            File.Move(theFile.FullName, this.m_workPath + "\\" + Path.GetFileName(theFile.FullName));

                        }
                    }
                }
                //File.SetLastWriteTime(FileName, fileDate);

            }
            catch (Exception)
            {
                if (response != null)
                    response.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Download();
        }
        public int setConfig(string pro, string par, string val)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFile);
            try
            {
                xd.FirstChild.SelectSingleNode(pro).SelectSingleNode(par).InnerText = val;

                xd.Save(xmlFile);
                xd = null;
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public int setParConfig(string ItemName, string ItemValue)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFile);
            try
            {
                xd.FirstChild.SelectSingleNode(ItemName).InnerText = ItemValue;

                xd.Save(xmlFile);
                xd = null;
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public string getConfig(string pro, string par)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFile);
            try
            {
                string str = xd.FirstChild.SelectSingleNode(pro).SelectSingleNode(par).InnerText;
                xd = null;
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private string GetVersion()
        {
            string version = "";

            try
            {
                string strVersionPath = this.m_workPath + "version.txt";
                StreamReader sw = new StreamReader(strVersionPath);
                version = sw.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return version;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //http://localhost:8003/Content/bootstrap.css
            string u = @"http://localhost:8003/Content/桌面壁纸.zip";
            DownloadFile("桌面壁纸.zip", u);
        }

        public void DownLoadFile()
        {
            //if (!Directory.Exists(UpdateFiles))
            //{
            //    Directory.CreateDirectory(UpdateFiles);
            //}
            string u = @"http://localhost:8003/Content/桌面壁纸.zip";
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    webClient.DownloadFileAsync(new Uri(u),  "UpdateFile.zip");
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.label1.Text = "下载完成";
                //复制更新文件替换旧文件
                //DirectoryInfo TheFolder = new DirectoryInfo(UpdateFiles);
                //foreach (FileInfo NextFile in TheFolder.GetFiles())
                //{
                //    File.Copy(NextFile.FullName, Application.StartupPath NextFile.Name, true);
                //}

            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Minimum = 0;
            this.uiProcessBar1.Maximum = (int)e.TotalBytesToReceive;
            this.uiProcessBar1.Value = (int)e.BytesReceived;
            this.label1.Text = e.ProgressPercentage + "%";
            //Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DownLoadFile();
        }
    }
}
