using AutoMapper;
using StatisticalProcess.Application.Models.Measurement;
using StatisticProcess.Domain.Entities;
using StatisticProcess.Domain.Entitys;

namespace StatisticalProcess.Application.Mappers
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MeasurementData, MeasurementDataModel>().ReverseMap();
            CreateMap<QuoteData, QuoteDataModel>().ReverseMap();
        }
    }
}
