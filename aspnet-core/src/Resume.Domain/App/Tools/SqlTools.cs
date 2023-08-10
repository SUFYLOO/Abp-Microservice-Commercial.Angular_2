using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{


    public static class SqlTools
    {
        /// <summary>
        /// Sql語句是否正確(只驗證不執行Sql)
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="Database"></param>
        /// <param name="DBuid"></param>
        /// <param name="DBpwd"></param>
        /// <param name="SqlString"></param>
        /// <returns>bool</returns>
        public static bool ValidateSql(string Server, string Database, string DBuid, string DBpwd, string SqlString)
        {
            bool Result;
            using (SqlConnection conn = OpenSqlConn(Server, Database, DBuid, DBpwd))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SET PARSEONLY ON ";
                    cmd.ExecuteNonQuery();
                    try
                    {
                        cmd.CommandText = SqlString;
                        cmd.ExecuteNonQuery();
                        Result = true;
                    }
                    catch (Exception)
                    {
                        Result = false;
                    }
                    finally
                    {
                        cmd.CommandText = "SET PARSEONLY OFF";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return Result;
        }

        public static SqlConnection OpenSqlConn(string Server, string Database, string DBuid, string DBpwd)
        {
            string cnstr = string.Format("server={0};database={1};uid={2};pwd={3};Connect Timeout = 180", Server, Database, DBuid, DBpwd);
            SqlConnection icn = new SqlConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;
        }

        public static DataTable GetSqlDataTable(string Server, string Database, string DBuid, string DBpwd, string SqlString, List<SqlParameter> ListParameter = null)
        {
            DataTable myDataTable = new DataTable();
            SqlConnection icn = null;
            icn = OpenSqlConn(Server, Database, DBuid, DBpwd);
            return GetSqlDataTable(icn, SqlString, ListParameter);
        }

        public static DataTable GetSqlDataTable(SqlConnection icn, string SqlString, List<SqlParameter> ListParameter = null)
        {
            DataTable myDataTable = new DataTable();
            SqlCommand isc = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = SqlString;
            isc.CommandTimeout = 600;
            if (ListParameter != null && ListParameter.Count > 0)
                isc.Parameters.AddRange(ListParameter.ToArray<SqlParameter>());
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static DataTable GetSqlDataTableColumn(string Server, string Database, string DBuid, string DBpwd, string SqlString, List<SqlParameter> ListParameter = null)
        {
            DataTable myDataTable = new DataTable();
            SqlConnection icn = null;
            icn = OpenSqlConn(Server, Database, DBuid, DBpwd);
            return GetSqlDataTableColumn(icn, SqlString, ListParameter);
        }

        public static DataTable GetSqlDataTableColumn(SqlConnection icn, string SqlString, List<SqlParameter> ListParameter = null)
        {
            DataTable myDataTable = new DataTable();
            SqlCommand isc = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = "SELECT TOP 0 " + SqlString.Trim().Substring(6);
            isc.CommandTimeout = 600;
            if (ListParameter != null && ListParameter.Count > 0)
                isc.Parameters.AddRange(ListParameter.ToArray<SqlParameter>());
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static void SqlInsertUpdateDelete(string Server, string Database, string DBuid, string DBpwd, string SqlString, List<SqlParameter> ListParameter = null)
        {
            SqlConnection icn = OpenSqlConn(Server, Database, DBuid, DBpwd);
            SqlInsertUpdateDelete(icn, SqlString, ListParameter);
        }

        public static void SqlInsertUpdateDelete(SqlConnection icn, string SqlString, List<SqlParameter> ListParameter = null)
        {
            SqlCommand cmd = new SqlCommand(SqlString, icn);
            if (ListParameter != null)
                cmd.Parameters.AddRange(ListParameter.ToArray<SqlParameter>());
            SqlTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }
    }

}
