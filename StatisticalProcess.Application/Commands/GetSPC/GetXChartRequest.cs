
using MediatR;
using StatisticalProcess.Application.Models.SPC;
using StatisticalProcess.Domain.Models;

namespace Sequor.QualitySyncData.Application.Commands.InspectionCommands.FindInspectionByMaterial
{
    public class GetXChartRequest : IRequest<ResponseStandard<ShewhartChart>>
    {
        public string DeviceCode { get; set; }
        public int SampleLenght { get; set; }
    }
}
