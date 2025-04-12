
using AutoMapper;
using MediatR;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Interfaces;

namespace Sequor.QualitySyncData.Application.Commands.InspectionCommands.FindInspectionByMaterial
{
    public class CreateManyMeasurementHandler(IMeasurementDataRepository measurementDataRepository, IMapper mapper) : IRequestHandler<CreateManyMeasurementRequest, ResponseStandard<bool>>
    {
        public async Task<ResponseStandard<bool>> Handle(CreateManyMeasurementRequest request, CancellationToken cancellationToken)
        {
            foreach (var measurement in request.measurements)
            {
                var measure = mapper.Map<MeasurementData>(measurement);

                await measurementDataRepository.InsertOneAsync(measure);
            }

            return new ResponseStandard<bool>(true)
                .SetSuccess(true)
                .AddMessage("Measurement data created successfully");
        }
    }
}
