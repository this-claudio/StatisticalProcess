using MediatR;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Interfaces;

namespace StatisticalProcess.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementHandler(IMeasurementDataRepository measurementDataRepository) : IRequestHandler<CreateMeasurementRequest, ResponseStandard<MeasurementData>>
    {
        public async Task<ResponseStandard<MeasurementData>> Handle(CreateMeasurementRequest request, CancellationToken cancellationToken)
        {
            var measure = new MeasurementData()
            {
                MeasurementDateTime = request.MeasurementDateTime,
                MeasurementValue = request.MeasurementValue,
                MaterialCode = request.MaterialCode,
                DeviceCode = request.DeviceCode
            };

            await measurementDataRepository.InsertOneAsync(measure);

            return new ResponseStandard<MeasurementData>(measure)
                .SetSuccess().AddMessage("Measurement data created successfully");
        }
    }
}
