using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WodeWinForm
{
   public class Common
   {
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

}
