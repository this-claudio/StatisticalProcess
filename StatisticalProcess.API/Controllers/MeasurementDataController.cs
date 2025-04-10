using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatisticalProcess.Application.Commands.CreateMeasurement;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using System.Threading.Tasks;

namespace StatisticalProcess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementDataController(IMediator mediator)
    {
        [HttpPost("[action]")]
        public async Task<ResponseStandard<MeasurementData>> CreateAsync([FromBody]CreateMeasurementRequest measurementData)
        {
            return await mediator.Send(measurementData);
        }

        [HttpGet("[action]")]
        public async Task<ResponseStandard<List<MeasurementData>>> ReadAllAsync()
        {
            return await mediator.Send(new ReadAllMeasurementRequest());
        }

    }
}
