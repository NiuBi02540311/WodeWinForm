using System;
using System.Collections;
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
using System.Xml.Serialization;

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

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName)
                {
                    item.Kill();
                    break;
                }
            }
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

    /// <summary>
    /// 转换扩展类
    /// </summary>
    public static class ConvertExtension
    {
        public static string ToString2(this object obj)
        {
            if (obj == null)
                return string.Empty;
            return obj.ToString();
        }

        public static DateTime? ToDateTime(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            if (DateTime.TryParse(str, out DateTime dateTime))
            {
                return dateTime;
            }
            return null;
        }

        public static bool ToBoolean(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return str.ToLower() == bool.TrueString.ToLower();
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static int ToInt(this string str)
        {
            if (int.TryParse(str, out int intValue))
            {
                return intValue;
            }
            return 0;
        }

        public static long ToLong(this string str)
        {
            if (long.TryParse(str, out long longValue))
            {
                return longValue;
            }
            return 0;
        }

        public static decimal ToDecimal(this string str)
        {
            if (decimal.TryParse(str, out decimal decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        public static double ToDouble(this string str)
        {
            if (double.TryParse(str, out double doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        public static float ToFloat(this string str)
        {
            if (float.TryParse(str, out float floatValue))
            {
                return floatValue;
            }
            return 0;
        }

        /// <summary>
        /// DataRow转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ConvertToEntityByDataRow<T>(this DataRow dataRow) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            T t = new T();
            if (dataRow == null) return t;
            foreach (PropertyInfo property in properties)
            {
                foreach (DataColumn column in dataRow.Table.Columns)
                {
                    if (property.Name.Equals(column.ColumnName, StringComparison.OrdinalIgnoreCase))
                    {
                        object value = dataRow[column];
                        if (value != null && value != DBNull.Value)
                        {
                            if (value.GetType().Name != property.PropertyType.Name)
                            {
                                if (property.PropertyType.IsEnum)
                                {
                                    property.SetValue(t, Enum.Parse(property.PropertyType, value.ToString()), null);
                                }
                                else
                                {
                                    try
                                    {
                                        value = Convert.ChangeType(value, (Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType));
                                        property.SetValue(t, value, null);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                property.SetValue(t, value, null);
                            }
                        }
                        else
                        {
                            property.SetValue(t, null, null);
                        }
                        break;
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 通用简单实体类型互转
        /// </summary>
        public static T ConvertToEntity<T>(this object sourceEntity) where T : new()
        {
            T t = new T();
            Type sourceType = sourceEntity.GetType();
            if (sourceType.Equals(typeof(DataRow)))
            {
                //DataRow类型
                DataRow dataRow = sourceEntity as DataRow;
                t = dataRow.ConvertToEntityByDataRow<T>();
            }
            else
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                PropertyInfo[] sourceProperties = sourceType.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    foreach (var sourceProperty in sourceProperties)
                    {
                        if (sourceProperty.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            object value = sourceProperty.GetValue(sourceEntity, null);
                            if (value != null && value != DBNull.Value)
                            {
                                if (sourceProperty.PropertyType.Name != property.PropertyType.Name)
                                {
                                    if (property.PropertyType.IsEnum)
                                    {
                                        property.SetValue(t, Enum.Parse(property.PropertyType, value.ToString()), null);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            value = Convert.ChangeType(value, (Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType));
                                            property.SetValue(t, value, null);
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    property.SetValue(t, value, null);
                                }
                            }
                            else
                            {
                                property.SetValue(t, null, null);
                            }
                            break;
                        }
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 通用简单实体类型互转
        /// </summary>
        public static List<T> ConvertToEntityList<T>(this object list) where T : new()
        {
            List<T> t = new List<T>();
            if (list == null) return t;
            Type sourceObj = list.GetType();
            if (sourceObj.Equals(typeof(DataTable)))
            {
                var dataTable = list as DataTable;
                t = dataTable.Rows.Cast<DataRow>().Where(m => !(m.RowState == DataRowState.Deleted || m.RowState == DataRowState.Detached)).Select(m => m.ConvertToEntityByDataRow<T>()).ToList();
            }
            else if (list is IEnumerable)
            {
                t = ((IList)list).Cast<object>().Select(m => m.ConvertToEntity<T>()).ToList();
            }
            return t;
        }

        /// <summary>
        /// 转换为DataTable，如果是集合没有数据行的时候会抛异常。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(this object list)
        {
            if (list == null) return null;
            DataTable dataTable = new DataTable();
            if (list is IEnumerable)
            {
                var li = (IList)list;
                //li[0]代表的是一个对象，list没有行时，会抛异常。
                PropertyInfo[] properties = li[0].GetType().GetProperties();
                dataTable.Columns.AddRange(properties.Where(m => !m.PropertyType.IsClass || !m.PropertyType.IsInterface).Select(m =>
                    new DataColumn(m.Name, Nullable.GetUnderlyingType(m.PropertyType) ?? m.PropertyType)).ToArray());
                foreach (var item in li)
                {
                    DataRow dataRow = dataTable.NewRow();
                    foreach (PropertyInfo property in properties.Where(m => m.PropertyType.GetProperty("Item") == null))    //过滤含有索引器的属性
                    {
                        object value = property.GetValue(item, null);
                        dataRow[property.Name] = value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            else
            {
                PropertyInfo[] properties = list.GetType().GetProperties();
                properties = properties.Where(m => m.PropertyType.GetProperty("Item") == null).ToArray();   //过滤含有索引器的属性
                dataTable.Columns.AddRange(properties.Select(m => new DataColumn(m.Name, Nullable.GetUnderlyingType(m.PropertyType) ?? m.PropertyType)).ToArray());
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(list, null);
                    dataRow[property.Name] = value ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 实体类公共属性值复制
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="target"></param>
        public static void CopyTo(this object entity, object target)
        {
            if (target == null) return;
            if (entity.GetType() != target.GetType())
                return;
            PropertyInfo[] properties = target.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.GetProperty("Item") != null)
                    continue;
                object value = property.GetValue(entity, null);
                if (value != null)
                {
                    if (value is ICloneable)
                    {
                        property.SetValue(target, (value as ICloneable).Clone(), null);
                    }
                    else
                    {
                        property.SetValue(target, value.Copy(), null);
                    }
                }
                else
                {
                    property.SetValue(target, null, null);
                }
            }
        }

        public static object Copy(this object obj)
        {
            if (obj == null) return null;
            object targetDeepCopyObj;
            Type targetType = obj.GetType();
            if (targetType.IsValueType == true)
            {
                targetDeepCopyObj = obj;
            }
            else
            {
                targetDeepCopyObj = Activator.CreateInstance(targetType);   //创建引用对象
                MemberInfo[] memberCollection = obj.GetType().GetMembers();

                foreach (MemberInfo member in memberCollection)
                {
                    if (member.GetType().GetProperty("Item") != null)
                        continue;
                    if (member.MemberType == MemberTypes.Field)
                    {
                        FieldInfo field = (FieldInfo)member;
                        object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                        {
                            field.SetValue(targetDeepCopyObj, (fieldValue as ICloneable).Clone());
                        }
                        else
                        {
                            field.SetValue(targetDeepCopyObj, fieldValue.Copy());
                        }
                    }
                    else if (member.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo property = (PropertyInfo)member;
                        MethodInfo method = property.GetSetMethod(false);
                        if (method != null)
                        {
                            object propertyValue = property.GetValue(obj, null);
                            if (propertyValue is ICloneable)
                            {
                                property.SetValue(targetDeepCopyObj, (propertyValue as ICloneable).Clone(), null);
                            }
                            else
                            {
                                property.SetValue(targetDeepCopyObj, propertyValue.Copy(), null);
                            }
                        }
                    }
                }
            }
            return targetDeepCopyObj;
        }
    }

    public class FileHelper
    {
        private readonly string strUpdateFilesPath;

        public FileHelper(string strDirector)
        {
            strUpdateFilesPath = strDirector;
        }

        //保存所有的文件信息
        private List<FileInfo> listFiles = new List<FileInfo>();

        public List<FileInfo> GetAllFilesInDirectory(string strDirector)
        {
            DirectoryInfo directory = new DirectoryInfo(strDirector);
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            FileInfo[] fileInfoArray = directory.GetFiles();
            if (fileInfoArray.Length > 0) listFiles.AddRange(fileInfoArray);

            foreach (DirectoryInfo item in directoryArray)
            {
                DirectoryInfo directoryA = new DirectoryInfo(item.FullName);
                DirectoryInfo[] directoryArrayA = directoryA.GetDirectories();
                GetAllFilesInDirectory(item.FullName);
            }
            return listFiles;
        }

        public string[] GetUpdateList(List<FileInfo> listFileInfo)
        {
            var fileArrary = listFileInfo.Cast<FileInfo>().Select(s => s.FullName.Replace(strUpdateFilesPath, "")).ToArray();
            return fileArrary;
        }

        /// <summary>
        /// 删除文件夹下的所有文件但不删除目录
        /// </summary>
        /// <param name="dirRoot"></param>
        public static void DeleteDirAllFile(string dirRoot)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(dirRoot));
            FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo item in files)
            {
                File.Delete(item.FullName);
            }
        }
    }

    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public static class XmlUtility
    {
        #region 序列化

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion 序列化

        #region 反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }

        #endregion 反序列化
    }

  

}
