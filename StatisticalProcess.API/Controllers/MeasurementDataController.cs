using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sequor.QualitySyncData.Application.Commands.InspectionCommands.FindInspectionByMaterial;
using StatisticalProcess.Application.Commands.CreateMeasurement;
using StatisticalProcess.Application.Models.SPC;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;

namespace StatisticalProcess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementDataController(IMediator mediator)
    {
        [HttpPost("[action]")]
        public async Task<ResponseStandard<MeasurementData>> CreateAsync([FromBody] CreateMeasurementRequest measurementData)
        {
            return await mediator.Send(measurementData);
        }

        [HttpPost("[action]")]
        public async Task<ResponseStandard<bool>> CreateManyAsync([FromBody] CreateManyMeasurementRequest measurementData)
        {
            return await mediator.Send(measurementData);
        }

        [HttpGet("[action]")]
        public async Task<ResponseStandard<List<MeasurementData>>> ReadAllAsync()
        {
            return await mediator.Send(new ReadAllMeasurementRequest());
        }

        [HttpGet("[action]/{deviceCode}/{sampleLenght}")]
        public async Task<ResponseStandard<ShewhartChart>> GetXChartAsync([FromRoute] string deviceCode, int sampleLenght)
        {
            return await mediator.Send(new GetXChartRequest() { DeviceCode = deviceCode, SampleLenght = sampleLenght });
        }

        [HttpGet("[action]/{deviceCode}/{sampleLenght}")]
        public async Task<ResponseStandard<ShewhartChart>> GetRChartAsync([FromRoute] string deviceCode, int sampleLenght)
        {
            return await mediator.Send(new GetXChartRequest() { DeviceCode = deviceCode, SampleLenght = sampleLenght });
        }

    }
}
