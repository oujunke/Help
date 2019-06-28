using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace Help.DataHelp.SqlServerHelp
{
    public static class DBHelp
    {
        //private static string ConStrName;
        //{
        //    set
        //    {
        //        ConStrName = value;
        //    }
        //    get
        //    {
        //        if (ConStrName == null)
        //        {
        //            throw new Exception("未将ConStr赋值");
        //        }
        //        return ConStrName;
        //    }
        //}
        private static string strConn;

        public static void SetStrCon(string vaule)
        {
            strConn = ConfigurationManager.ConnectionStrings[vaule].ConnectionString;
        }

        #region 利用泛型加反射直接返回List集合
        public static List<T> GetList<T>(string cmdText, params object[] parameter)
        {
            DataTable dt = GetDataTable(cmdText, parameter);
            return DataTableToList<T>(dt);
        }
        private static List<T> DataTableToList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            T t = default(T);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    t = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        prop.SetValue(t, dr[prop.Name],null);
                    }
                    list.Add(t);
                }
            }
            catch
            {
            }
            if (list.Count == 0) return null;
            else return list;
        }
        public static List<T> GetList<T>(string cmdText)
        {
            DataTable dt = GetDataTable(cmdText);
            return DataTableToList<T>(dt);
        }
        public static T GetT<T>(string cmdText, params object[] parameter)
        {
            DataTable dt = GetDataTable(cmdText, parameter);
            return DataTableToT<T>(dt);
        }
        private static T DataTableToT<T>(DataTable dt)
        {
            T t = default(T);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    t = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        prop.SetValue(t, dr[prop.Name],null);
                    }
                    return t;
                }
            }
            catch
            {
            }
            return t;
        }
        public static T GetT<T>(string cmdText)
        {
            DataTable dt = GetDataTable(cmdText);
            return DataTableToT<T>(dt);
        }
        #endregion

        #region 执行SQL语句或贮存过程返回DataTable
        /// <summary>
        /// 执行SQL语句或贮存过程返回DataTable
        /// </summary>
        /// <param name="cmdText">SQL语句或贮存过程</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText)
        {
            SqlConnection conn = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            { conn.Dispose(); }
        }

        /// <summary>
        /// 执行带参数的SQL语句返回DataTable
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText, params object[] parameter)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                AddComParameter(parameter,cmd);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt;
            }
            catch
            {
                return dt;
            }
            finally { conn.Close(); conn.Dispose(); }
        }
        /// <summary>
        /// 执行带参数的SQL语句或贮存过程返回DataTable
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句或贮存过程</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <param name="commType">命令类型</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText, System.Data.CommandType commType, params object[] parameter)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = commType;
                AddComParameter(parameter,cmd);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt;
            }
            catch
            {
                return dt;
            }
            finally { conn.Close(); conn.Dispose(); }
        }
        #endregion

        #region 执行SQL语句或贮存过程返回受影响的行数

        /// <summary>
        /// 执行SQL语句返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行SQL语句或贮存过程返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句或贮存过程</param>
        /// <param name="cmdType">是SQL语句还是贮存过程</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, System.Data.CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdType;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch
            {
                return 0;
            }
            finally { conn.Close(); conn.Dispose(); }
        }

        /// <summary>
        /// 执行带参数的SQL语句或贮存过程返回受影响的行数
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句或贮存过程</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params object[] parameter)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, parameter);
        }

        /// <summary>
        /// 执行带参数的SQL语句或贮存过程返回受影响的行数
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句或贮存过程</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <param name="cmdType">是SQL语句还是贮存过程</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, System.Data.CommandType cmdType, params object[] parameter)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdType;
                AddComParameter(parameter,cmd);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch
            {
                return 0;
            }
            finally { conn.Close(); conn.Dispose(); }
        }

        /// <summary>
        /// 执行多条SQL语句（事务方式）返回是否成功
        /// </summary>
        /// <param name="cmdTexts">SQL语句的泛型集合</param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(List<string> cmdTexts)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            SqlTransaction st = conn.BeginTransaction();
            cmd.Transaction = st;
            try
            {
                foreach (string sql in cmdTexts)
                {
                    cmd.CommandText = sql;
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)//只要有一个结果不对，回滚事务
                        st.Rollback();
                }

                st.Commit();
                return true;
            }
            catch
            {
                st.Rollback();
                return false;
            }
            finally { conn.Close(); conn.Dispose(); }
        }

        #endregion

        #region 执行SQL语句或贮存过程返回第一行第一列的值
        /// <summary>
        /// 执行SQL语句返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText, CommandType.Text);
        }
        /// <summary>
        /// 执行SQL语句或贮存过程返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText">SQL语句或贮存过程</param>
        /// <param name="cmdType">指定是SQL语句还是贮存过程</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, System.Data.CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdType;
                conn.Open();
                object i = cmd.ExecuteScalar();
                return i;
            }
            catch
            {
                return null;
            }
            finally { conn.Close(); conn.Dispose(); }
        }
        /// <summary>
        /// 执行带参数的SQL语句返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, params object[] parameter)
        {
            return ExecuteScalar(cmdText, CommandType.Text, parameter);
        }
        /// <summary>
        /// 执行SQL语句或贮存过程返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText">带参数的SQL语句或贮存过程</param>
        /// <param name="parameter">将各参数形成的Dictionary〈参数名,参数值〉</param>
        /// <param name="cmdType">指定是SQL语句还是贮存过程</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, System.Data.CommandType cmdType, params object[] parameter)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdType;
                AddComParameter(parameter,cmd);
                conn.Open();
                object i = cmd.ExecuteScalar();
                return i;
            }
            catch
            {
                return null;
            }
            finally { conn.Close(); conn.Dispose(); }
        }
        #endregion
        
        #region 添加参数
        private static void AddComParameter(object[] parameter, SqlCommand com)
        {
            if (parameter != null && parameter.Length > 0 && parameter.Length % 2 == 0)
            {
                SqlParameter sp = null;
                for (int i = 0; i < parameter.Length; i = i + 2)
                {
                    sp = new SqlParameter(parameter[i].ToString(), parameter[i + 1]);
                    com.Parameters.Add(sp);
                }
            }
        }
        #endregion
    }
}
