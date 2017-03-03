using BitirmeDRM.Data.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Core.Infrastructure
{
    class SqlFunction
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;

        /// <summary>
        /// ExecuteType = 1(ExecuteNonQuery Sorguları İşlenir), ExecuteType = 2(ExecuteScalar Sorguları İşlenir)
        /// </summary>
        /// <param name="ExecuteType"></param>
        /// <param name="SqlSorgu"></param>
        /// <returns></returns>
        public object GetCommand(int ExecuteType, string SqlSorgu)
        {
            object sonuc = 0;
            conn = Connection.ConnectionString();
            conn.Open();
            cmd = new SqlCommand(SqlSorgu, conn);

            if (ExecuteType == 1)
            {
                sonuc = cmd.ExecuteNonQuery();
            }
            else if (ExecuteType == 2)
            {
                sonuc = cmd.ExecuteScalar();
            }
            conn.Close();
            cmd.Dispose();

            return sonuc;
        }

        public int GetNonQuery(string SqlProcedure, SqlParameter[] Parameters)
        {
            conn = Connection.ConnectionString();
            conn.Open();
            cmd = new SqlCommand(SqlProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int result = -1;
            try
            {
                if (Parameters != null)
                {
                    for (int i = 0; i < Parameters.Length; i++)
                    {
                        cmd.Parameters.Add(Parameters[i]);
                    }
                }
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                result = 0;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }

            return result;
        }

        public DataSet GetDataSet(string SqlProcedure, SqlParameter[] Parameters)
        {
            conn = Connection.ConnectionString();
            cmd = new SqlCommand(SqlProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();

            try
            {
                if (Parameters != null)
                {
                    for (int i = 0; i < Parameters.Length; i++)
                    {
                        cmd.Parameters.Add(Parameters[i]);
                    }
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch
            {
            }
            finally
            {
                conn.Open();
                cmd.Dispose();
            }
            return ds;
        }

        public DataTable GetDataTable(string SqlProcedure, SqlParameter[] Parameters)
        {
            conn = Connection.ConnectionString();
            cmd = new SqlCommand(SqlProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            try
            {
                if (Parameters != null)
                {
                    for (int i = 0; i < Parameters.Length; i++)
                    {
                        cmd.Parameters.Add(Parameters[i]);
                    }
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable GetDataTable(string SqlQuery)
        {
            conn = Connection.ConnectionString();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(SqlQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable GetDataTablePaging(string SqlProcedure, SqlParameter[] Parameters, int CurrentPage, int PageSize, string Table)
        {
            conn = Connection.ConnectionString();
            DataSet ds = new DataSet();
            cmd = new SqlCommand(SqlProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            try
            {
                if (Parameters != null)
                {
                    for (int i = 0; i < Parameters.Length; i++)
                    {
                        cmd.Parameters.Add(Parameters[i]);
                    }
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, CurrentPage, PageSize, Table);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable GetDataTablePaging(string SqlQuery, int CurrentPage, int PageSize, string Table)
        {
            conn = Connection.ConnectionString();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(SqlQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, CurrentPage, PageSize, Table);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public DataRow GetDataRow(string SqlProcedure, SqlParameter[] Parameters)
        {
            try
            {
                DataTable dt = GetDataTable(SqlProcedure, Parameters);
                if (dt.Rows.Count == 0) return null;
                return dt.Rows[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        public DataRow GetDataRow(string SqlQuery)
        {
            conn = Connection.ConnectionString();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(SqlQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count == 0) return null;

            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt.Rows[0];
        }

        public string GetDataCell(string SqlProcedure, SqlParameter[] Parameters)
        {
            string sonuc = null;
            try
            {
                DataTable dt = GetDataTable(SqlProcedure, Parameters);
                if (dt.Rows.Count == 0) return null;

                sonuc = dt.Rows[0][0].ToString();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return sonuc;
        }

        public string GetDataCell(string SqlQuery)
        {
            string sonuc = null;
            try
            {
                DataTable dt = GetDataTable(SqlQuery);
                if (dt.Rows.Count == 0) return null;

                sonuc = dt.Rows[0][0].ToString();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return sonuc;
        }


    }

}
