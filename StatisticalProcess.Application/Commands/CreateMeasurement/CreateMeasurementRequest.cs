using MediatR;
using StatisticalProcess.Application.Models.Measurement;
using StatisticalProcess.Domain.Models;

namespace StatisticalProcess.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementRequest : MeasurementDataModel, IRequest<ResponseStandard<MeasurementDataModel>>
    {
    }
}
