using AutoMapper;
using AutoMapper.Configuration;
using MyWebAPI.Dtos;
using MyWebAPI.Models;
using MyWebAPI.Repository;
using MyWebAPI.Service;
using Newtonsoft.Json.Linq;

namespace MyWebAPI.TestUseCase
{
    public class FinancialRecordsUseCase
    {
        private readonly IMapper _mapper;
        public FinancialRecordsUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual async Task<FinancialRecordDtoList> QueryDataBase(int 公司代號)
        {
            try
            {
                List<FinancialRecordModel> result = await Task.FromResult<List<FinancialRecordModel>>(new FinancialRecords().QueryData(公司代號).ToList());
                List<FinancialRecordDto> map = _mapper.Map<List<FinancialRecordDto>>(result);
                return new FinancialRecordDtoList()
                {
                    Success = true,
                    Data = map,
                    Message = $"完成",
                    TotalCount = result.Count,
                    TotalPage = 0,
                    PageNo = 0,
                    PageSize = 0
                };
            }
            catch (Exception ex)
            {
                return new FinancialRecordDtoList()
                {
                    Success = false,
                    Data = new List<FinancialRecordDto>(),
                    Message = ex.ToString(),
                    TotalCount = 0,
                    TotalPage = 0,
                    PageNo = 0,
                    PageSize = 0
                };
            }

        }


        public virtual async Task<FinancialRecordList> ModifyData(FinancialRecordModel model,string type)
        {
            try
            {
                var result = await Task.FromResult(new FinancialRecords().ModifyData(model,type));
                return new FinancialRecordList()
                {
                    Success = (result == -1) ? false : true,
                    Data = new List<FinancialRecordModel>(){ model},
                    Message = (result==-1)?"失敗":"成功",
                    TotalCount = 0,
                    TotalPage = 0,
                    PageNo = 0,
                    PageSize = 0
                };
            }
            catch (Exception ex)
            {
                return new FinancialRecordList()
                {
                    Success = false,
                    Data = new List<FinancialRecordModel>(),
                    Message = ex.ToString(),
                    TotalCount = 0,
                    TotalPage = 0,
                    PageNo = 0,
                    PageSize = 0
                };
            }
        }
    }
}
