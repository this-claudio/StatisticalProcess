namespace StatisticalProcess.Application.Models.Measurement
{
    public class MeasurementDataModel
    {
        public DateTime MeasurementDateTime { get; set; }
        public string DeviceCode { get; set; }
        public List<QuoteDataModel> Quotes { get; set; } = new List<QuoteDataModel>();
    }
}
