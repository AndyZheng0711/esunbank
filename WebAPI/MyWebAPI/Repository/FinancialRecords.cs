using MyWebAPI.Models;
using NLog;
using System.Data;
using System.Data.SqlClient;

namespace MyWebAPI.Repository
{
    public class FinancialRecords
    {
        /// <summary>
        /// 取得資料明細
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public IEnumerable<FinancialRecordModel> QueryData(int 公司代號)
        {
            try
            {
                FinancialRecordModel model = new FinancialRecordModel
                {
                    公司代號 = 公司代號,
                    公司名稱 = "",
                    產業別 = "",
                };

                Service.sqlConn db = new Service.sqlConn();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    db.AddSqlParameter("公司代號",model.公司代號),
                    db.AddSqlParameter("公司名稱",model.公司名稱),
                    db.AddSqlParameter("產業別",model.產業別),
                };

                DataTable dtResult = db.GetQueryByProcedure("SP_GET_t187ap05_L", parameters);
                IEnumerable<FinancialRecordModel> lstResult = new Service.DataTransaction().DataTableToList<FinancialRecordModel>(dtResult);

                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Trace("OK");
                return lstResult;
            }
            catch (Exception ex)
            {
                DataTable dtResult = new DataTable();
                IEnumerable<FinancialRecordModel> lstResult = new Service.DataTransaction().DataTableToList<FinancialRecordModel>(dtResult);

                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex);
                return lstResult;
            }
        }

        public int ModifyData(FinancialRecordModel model,string type)
        {
            var Result = 0;
            try
            {
                Service.sqlConn db = new Service.sqlConn();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    db.AddSqlParameter("Type",type),
                    db.AddSqlParameter("出表日期", model.出表日期),
                    db.AddSqlParameter("資料年月", model.資料年月),
                    db.AddSqlParameter("公司代號", model.公司代號),
                    db.AddSqlParameter("公司名稱", model.公司名稱),
                    db.AddSqlParameter("產業別", model.產業別),
                    db.AddSqlParameter("營業收入_當月營收", model.營業收入_當月營收),
                    db.AddSqlParameter("營業收入_上月營收", model.營業收入_上月營收),
                    db.AddSqlParameter("營業收入_去年當月營收", model.營業收入_去年當月營收),
                    db.AddSqlParameter("累計營業收入_去年累計營收", model.累計營業收入_去年累計營收),
                    db.AddSqlParameter("累計營業收入_當月累計營收", model.累計營業收入_當月累計營收),
                    db.AddSqlParameter("營業收入_上月比較增減", model.營業收入_上月比較增減),
                    db.AddSqlParameter("營業收入_去年同月增減", model.營業收入_去年同月增減),
                    db.AddSqlParameter("累計營業收入_前期比較增減", model.累計營業收入_前期比較增減),
                    db.AddSqlParameter("備註", model.備註)
                };
                Result = db.ModifyDataByProcedure("SP_MOD_t187ap05_L", parameters);
                
                if (!Result.Equals(-1)) 
                {
                    //Log記錄
                    var log = LogManager.GetCurrentClassLogger();
                    log.Trace("OK");
                }
            }
            catch (Exception ex)
            {
                //Log記錄
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex);
            }
            return Result;
        }
    }
}
