using StatisticProcess.Domain.Entities;

namespace StatisticProcess.Domain.Entitys
{
    public class MeasurementData : BaseEntity
    {
        public MeasurementData(decimal measurementValue, DateTime measurementDateTime, string deviceCode, string materialCode)
        {
            MeasurementValue = measurementValue;
            MeasurementDateTime = measurementDateTime;
            DeviceCode = deviceCode;
            MaterialCode = materialCode;
        }

        public MeasurementData() { }

        private decimal measurementValue;
        private DateTime measurementDateTime;
        private string deviceCode;
        private string materialCode;
        private List<QuoteDate> quotes;

        public decimal MeasurementValue { get => measurementValue; set => measurementValue = value; }
        public DateTime MeasurementDateTime { get => measurementDateTime; set => measurementDateTime = value; }
        public string DeviceCode { get => deviceCode; set => deviceCode = (value ?? "").Trim(); }
        public string MaterialCode { get => materialCode; set => materialCode = (value ?? "").Trim(); }

        public List<QuoteDate> Quotes
        {
            get => quotes;
            set
            {
                if (value == null)
                {
                    quotes = new List<QuoteDate>();
                }
                else
                {
                    quotes = value;
                }
            }
        }
    }
}
