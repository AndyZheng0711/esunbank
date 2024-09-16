using AutoMapper;
using MyWebAPI.Dtos;
using MyWebAPI.Models;

namespace MyWebAPI.Mappings
{
    public class FinancialRecordsProfile : Profile
    {
        public FinancialRecordsProfile()
        {
            //CreateMap<FinancialRecordModel,FinancialRecordDto>();
            CreateMap<FinancialRecordModel, FinancialRecordDto>()
                .ForMember(
                dest => dest.公司代號,
                opt => opt.MapFrom(src => 0)
                );
        }
    }
}
