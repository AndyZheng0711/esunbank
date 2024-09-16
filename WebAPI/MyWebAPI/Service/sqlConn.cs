using Microsoft.Extensions.Configuration;
using MyWebAPI.Models;
using NLog;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace MyWebAPI.Service
{
    public class sqlConn
    {
        /// <summary>
        /// 讀取資料庫連接設定
        /// </summary>
        /// <returns></returns>
        private string? connString()
        {
            string? connectionString = "";
            try
            {
                var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");
                var config = builder.Build();
                connectionString = config.GetConnectionString("DefaultConnection");

                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Debug("OK");
            }
            catch (Exception ex)
            {
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex);
            }
            return connectionString;
        }

        /// <summary>
        /// 查詢資料Procedure
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="pParam"></param>
        /// <returns></returns>
        public DataTable GetQueryByProcedure(string ProcedureName, SqlParameter[] pParam)
        {
            DataTable dtResult = new DataTable();
            string? strConn = connString();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn)) 
                {
                    using (SqlCommand cmd = new SqlCommand(ProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(pParam);
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtResult);
                        }
                        conn.Close();
                    }
                }
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Debug("OK");
            }
            catch (Exception ex)
            {
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex);
            }
            return dtResult;
        }

        /// <summary>
        /// 修改資料Procedure
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="pParam"></param>
        /// <returns></returns>
        public int ModifyDataByProcedure(string ProcedureName, SqlParameter[] pParam)
        {
            int intResult = 0;
            string? strConn = connString();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(pParam);
                        intResult = cmd.ExecuteNonQuery();
                    }
                }
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Debug("OK");
            }
            catch (Exception ex)
            {

                intResult = -1;
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex);
            }
            return intResult;
        }

        #region Add Parameter
        /// <summary>
        /// 新增Parameter
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="Direction"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SqlParameter AddSqlParameter(string ParameterName, ParameterDirection Direction, SqlDbType dbType, object value)
        {
            return new SqlParameter()
            {
                ParameterName = ParameterName,
                SqlDbType = dbType,
                Direction = Direction,
                Value = value
            };
        }


        /// <summary>
        /// 新增Parameter
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="Size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SqlParameter AddSqlParameter(string ParameterName, SqlDbType dbType,int Size, object value)
        {
            return new SqlParameter()
            {
                ParameterName = ParameterName,
                SqlDbType = dbType,
                Size = Size,
                Value = value
            };
        }

        /// <summary>
        /// 新增Parameter
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SqlParameter AddSqlParameter(string ParameterName, object value)
        {
            return new SqlParameter()
            {
                ParameterName = ParameterName,
                Value = value
            };
        }
        #endregion
    }
}
