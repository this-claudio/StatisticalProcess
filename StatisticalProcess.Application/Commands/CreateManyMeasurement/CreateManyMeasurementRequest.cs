
using MediatR;
using StatisticalProcess.Application.Models.Measurement;
using StatisticalProcess.Domain.Models;

namespace Sequor.QualitySyncData.Application.Commands.InspectionCommands.FindInspectionByMaterial
{
    public class CreateManyMeasurementRequest : IRequest<ResponseStandard<bool>>
    {
        public  List<MeasurementDataModel> measurements  { get; set; }
    }
}
