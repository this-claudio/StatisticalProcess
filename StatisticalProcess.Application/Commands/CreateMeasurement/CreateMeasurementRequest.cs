using MediatR;
using StatisticalProcess.Application.Models.Measurement;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalProcess.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementRequest : MeasurementDataModel, IRequest<ResponseStandard<MeasurementData>>
    {
    }
}
