using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
namespace Help.DataHelp.SqliteHelp
{
    /// <summary>
    /// 
    /// </summary>
    public class SqliteDBCommon
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetSqliteDbConnection(string databaseFileName)
        {
            SQLiteConnection sqliteDbConnection = new SQLiteConnection();
            if (File.Exists(databaseFileName))
            {
                try
                {
                    SQLiteConnectionStringBuilder scbuild = new SQLiteConnectionStringBuilder();
                    scbuild.DataSource = databaseFileName;
                    sqliteDbConnection.ConnectionString = scbuild.ToString();
                    sqliteDbConnection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("无法打开数据库连接：" + ex.ToString());
                }
            }
            return sqliteDbConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLSqlServerStringList"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<String> SQLSqlServerStringList, string databaseFileName)
        {
            using (SQLiteConnection con = GetSqliteDbConnection(databaseFileName))
            {
                SQLiteTransaction tx = null;
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    try
                    {
                        int count = 0;
                        //con.Open();
                        cmd.Connection = con;
                        tx = con.BeginTransaction();
                        cmd.Transaction = tx;
                        for (int n = 0; n < SQLSqlServerStringList.Count; n++)
                        {
                            string strsql = SQLSqlServerStringList[n];
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                count += cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                        return count;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        return 0;
                    }
                }
            }
        }
        public static System.Data.DataTable ExeuteDataTable(string sqlString)
        {
            return ExeuteDataTable(sqlString, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static System.Data.DataTable ExeuteDataTable(string sqlString, string databaseFileName)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = GetSqliteDbConnection(databaseFileName))
            {
                SQLiteDataAdapter dataAdaper = new SQLiteDataAdapter(sqlString, con);
                dataAdaper.Fill(dt);
                dataAdaper.Dispose();
                con.Close();
            }
            return dt;
        }
        public static object GetSingle(string SQLString)
        {
            return GetSingle(SQLString, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, string databaseFileName)
        {
            object obj = null;
            using (SQLiteConnection con = GetSqliteDbConnection(databaseFileName))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLString, con);

                try
                {
                    obj = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
                if (obj is System.DBNull)
                    obj = null;
            }
            return obj;
        }

        public static bool ExecuteNonQuery(string sqlString)
        {
            return ExecuteNonQuery(sqlString, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sqlString, string databaseFileName)
        {
            int result = -1;
            using (SQLiteConnection con = GetSqliteDbConnection(databaseFileName))
            {
                //con.Open();
                SQLiteCommand cmd = new SQLiteCommand(sqlString, con);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            return result > 0 ? true : false;
        }

    }
}
