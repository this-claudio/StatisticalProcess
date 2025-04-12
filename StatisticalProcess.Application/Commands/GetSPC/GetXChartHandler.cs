
using MediatR;
using StatisticalProcess.Application.Models.SPC;
using StatisticalProcess.Application.Utils.Contracts;
using StatisticalProcess.Domain.Models;
using StatisticProcess.Domain.Interfaces;

namespace Sequor.QualitySyncData.Application.Commands.InspectionCommands.FindInspectionByMaterial
{
    public class GetXChartHandler(IMeasurementDataRepository repository, ILimitsCoefficient coefficient) : IRequestHandler<GetXChartRequest, ResponseStandard<ShewhartChart>>
    {
        public async Task<ResponseStandard<ShewhartChart>> Handle(GetXChartRequest request, CancellationToken cancellationToken)
        {
            var Measurement = await repository.GetByDevice(request.DeviceCode, request.SampleLenght);

            var points = new List<GraphPoints>();
            var Amplitude = new List<decimal>();
            var maxQuoteLenght = 0;

            int index = 0;
            foreach (var measure in Measurement)
            {
                var average = measure.Quotes.Average(x => x.value);
                points.Add(new GraphPoints(index, average));
                Amplitude.Add(measure.Quotes.Max(x => x.value) - measure.Quotes.Min(x => x.value));


                var length = measure.Quotes.Count();
                if (length > maxQuoteLenght)
                    maxQuoteLenght = length;

                index++;
            }

            var AvarageOfAverage = points.Average(v => v.y);
            var AmplitudeOfAmplitude = (Amplitude.Max() - Amplitude.Min());

            if (maxQuoteLenght > 0 && maxQuoteLenght < 26)
            {
                var LSC = AvarageOfAverage + coefficient.A2.GetValueOrDefault(maxQuoteLenght) * AmplitudeOfAmplitude;
                var LIC = AvarageOfAverage - coefficient.A2.GetValueOrDefault(maxQuoteLenght) * AmplitudeOfAmplitude;

                var graph = new ShewhartChart()
                {
                    UCL = LSC,
                    LCL = LIC,
                    LC = AvarageOfAverage,
                    points = points
                };

                return new ResponseStandard<ShewhartChart>(graph)
                    .SetSuccess(true)
                    .AddMessage("Measurement data load successfully");
            }

            return new ResponseStandard<ShewhartChart>()
                .SetSuccess(false)
                .AddMessage("Error");
        }
    }
}
