using AutoMapper;
using MediatR;
using StatisticalProcess.Application.Models.Measurement;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Interfaces;

namespace StatisticalProcess.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementHandler(IMapper mapper, IMeasurementDataRepository measurementDataRepository) : IRequestHandler<CreateMeasurementRequest, ResponseStandard<MeasurementDataModel>>
    {
        public async Task<ResponseStandard<MeasurementDataModel>> Handle(CreateMeasurementRequest request, CancellationToken cancellationToken)
        {
            var measure = mapper.Map<MeasurementData>(request);

            var persistence = await measurementDataRepository.InsertOneAsync(measure);

            var response = mapper.Map<MeasurementDataModel>(persistence);

            return new ResponseStandard<MeasurementDataModel>(response)
                .SetSuccess(true).AddMessage("Measurement data created successfully");
        }
    }
}
