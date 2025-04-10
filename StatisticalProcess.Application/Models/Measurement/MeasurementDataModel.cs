using StatisticProcess.Domain.Entities;

namespace StatisticalProcess.Application.Models.Measurement
{
    public class MeasurementDataModel
    {
        public decimal MeasurementValue { get; set; }
        public DateTime MeasurementDateTime { get; set; }
        public string DeviceCode { get; set; }
        public string MaterialCode { get; set; }
        public List<QuoteDateModel> Quotes { get; set; } = new List<QuoteDateModel>();
    }
}
