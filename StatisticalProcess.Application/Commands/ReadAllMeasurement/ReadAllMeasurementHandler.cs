using MediatR;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Interfaces;

namespace StatisticalProcess.Application.Commands.CreateMeasurement
{
    public class ReadAllMeasurementHandler(IMeasurementDataRepository measurementDataRepository) : IRequestHandler<ReadAllMeasurementRequest, ResponseStandard<List<MeasurementData>>>
    {
        public async Task<ResponseStandard<List<MeasurementData>>> Handle(ReadAllMeasurementRequest request, CancellationToken cancellationToken)
        {
            var response = await measurementDataRepository.GetAllAsync();

            return new ResponseStandard<List<MeasurementData>>(response)
                .SetSuccess(true);
        }
    }
}
