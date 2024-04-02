using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WodeWinForm
{
   public class common
   {
        public static string AssemblyFileVersion()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            else
            {
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        //方法二
        //得到指定程序集版本
        private static string GetAssemblyVersion(string name)
        {
            byte[] filedata = File.ReadAllBytes(name + ".exe");
            return Assembly.Load(filedata).GetName().Version.ToString();

        }

        /// <summary>
        /// 启动一个软件，并传入参数
        /// </summary>
        /// <param name="runFilePath"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool StartProcess(string runFilePath, params string[] args)
        {
            string s = "";
            foreach (string arg in args)
            {
                s = s + arg + " ";
            }
            s = s.Trim();
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(runFilePath, s); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            process.Start();
            return true;
        }
 
    }
   public class DBHelper
    {
        public static string connstr = "server=.;database=V_Char;uid=sa;pwd=000000";
        //创建数据库连接对象
        public static SqlConnection conn;
        public static void initconn()
        {
            conn = new SqlConnection(connstr);
            conn.Open();
        }
        public static DataTable GetDataTable(string sqlstr)
        {
            //初始化连接
            initconn();
            //创建适配器
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
            //定义数据集
            DataSet ds = new DataSet();
            //填充数据
            sda.Fill(ds);
            //关闭
            conn.Close();
            //返回查询结果
            return ds.Tables[0];
        }
        public static bool ExecuteNonQuery(string sqlstr)
        {
            //初始化连接
            initconn();
            //创建命令
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            int n = comm.ExecuteNonQuery();
            conn.Close();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

   public class DBHelper2
    {
        //定义连接字符串
        private static string connStr = "server=.;database=oneWinFormDB;uid=sa;pwd=123456";
        /// <summary>
        /// 查询方法   DataSet
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>返回DataSet数据表格</returns>
        public static DataSet GetDataSet(string sql)
        {
            //创建数据库连接对象
            SqlConnection conn = new SqlConnection(connStr);
            //创建数据适配器对象
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            //创建空数据表格对象
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        /// <summary>
        /// 执行增删改查语句
        /// </summary>
        /// <param name="sql">增删改sql语句</param>
        /// <returns>返回增删改执行结果</returns>
        public static bool ExecuteNonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            //打开数据库连接
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery() > 0;
        }
        /// <summary>
        /// 执行集合函数操作 查询首行首列，返回object
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);//创建数据库连接对象
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    }

    public class DESKey
    {
        /// <summary>
        /// Des默认密钥向量
        /// </summary>
        public static byte[] IV = { 0x13, 0x35, 0x16, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// Des加解密钥必须8位
        /// </summary>
        public const string Key = "4hghhgg";
    }
    public class DES
    {
        /// <summary>
        /// Des加密 原文链接：httpss://blog.csdn.net/qq_38693757/article/details/125252813
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">des密钥，长度必须8位</param>
        /// <param name="iv">密钥向量</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptDes(string source, string key, byte[] iv)
        {
            using (DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider())
            {
                byte[] rgbKeys = GetDesKey(key),
                    rgbIvs = iv,
                    inputByteArray = Encoding.UTF8.GetBytes(source);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desProvider.CreateEncryptor(rgbKeys, rgbIvs), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">des密钥，长度必须8位</param>
        /// <param name="iv">密钥向量</param>
        /// <returns>解密后的字符串</returns>
        public static string DecryptDes(string source, string key, byte[] iv)
        {
            using (DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider())
            {
                byte[] rgbKeys = GetDesKey(key), rgbIvs = iv, inputByteArray = Convert.FromBase64String(source);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desProvider.CreateDecryptor(rgbKeys, rgbIvs), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cryptoStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 获取Des8位密钥
        /// </summary>
        /// <param name="key">Des密钥字符串</param>
        /// <returns>Des8位密钥</returns>
        private static byte[] GetDesKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "Des密钥不能为空");
            }
            if (key.Length > 8)
            {
                key = key.Substring(0, 8);
            }
            if (key.Length < 8)
            {
                // 不足8补全
                key = key.PadRight(8, '0');
            }
            return Encoding.UTF8.GetBytes(key);
        }
    }
 
                        

}
