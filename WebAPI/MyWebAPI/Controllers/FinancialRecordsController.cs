using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Dtos;
using MyWebAPI.Models;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{
    public class FinancialRecordsController : Controller
    {
        private IMapper _mapper;

        public FinancialRecordsController(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public IActionResult Index(IMapper mapper)
        {
            return View();
        }

        [HttpPost("GetData")]
        public Task<FinancialRecordDtoList> GetData(int 公司代號)
        {
            var result = new MyWebAPI.TestUseCase.FinancialRecordsUseCase(_mapper).QueryDataBase(公司代號);
            return result;
        }

        [HttpPost("InsertData")]
        public Task<FinancialRecordList> InsertData(string strJson)
        {
            //FinancialRecordsModel mod = new FinancialRecordsModel
            //{
            //    出表日期 = 1140912,
            //    資料年月 = 11409,
            //    公司代號 = 99999,
            //    公司名稱 = "測試公司2024",
            //    產業別 = "測試產業別",
            //    營業收入_當月營收 = 100,
            //    營業收入_上月營收 = 100,
            //    營業收入_去年當月營收 = 100,
            //    營業收入_上月比較增減 = 100,
            //    累計營業收入_當月累計營收 = 100,
            //    累計營業收入_去年累計營收 = 100,
            //    累計營業收入_前期比較增減 = 100,
            //    備註 = "我是測試新增"
            //};
            //strJson = JsonConvert.SerializeObject(mod);

            FinancialRecordModel? model = JsonConvert.DeserializeObject<FinancialRecordModel>(strJson);

            var result = new MyWebAPI.TestUseCase.FinancialRecordsUseCase(_mapper).ModifyData(model ?? new FinancialRecordModel(),"Insert");
            return result;
        }

        [HttpPost("UpdateData")]
        public Task<FinancialRecordList> UpdateData(string strJson)
        {
            //FinancialRecordsModel mod = new FinancialRecordsModel
            //{
            //    出表日期 = 1140912,
            //    資料年月 = 11409,
            //    公司代號 = 99999,
            //    公司名稱 = "測試公司2024",
            //    產業別 = "測試產業別",
            //    營業收入_當月營收 = 100,
            //    營業收入_上月營收 = 100,
            //    營業收入_去年當月營收 = 100,
            //    營業收入_上月比較增減 = 100,
            //    累計營業收入_當月累計營收 = 100,
            //    累計營業收入_去年累計營收 = 100,
            //    累計營業收入_前期比較增減 = 100,
            //    備註 = "我是測試新增"
            //};
            //strJson = JsonConvert.SerializeObject(mod);

            FinancialRecordModel? model = JsonConvert.DeserializeObject<FinancialRecordModel>(strJson);

            var result = new MyWebAPI.TestUseCase.FinancialRecordsUseCase(_mapper).ModifyData(model ?? new FinancialRecordModel(),"Update");
            return result;
        }
    }
}
