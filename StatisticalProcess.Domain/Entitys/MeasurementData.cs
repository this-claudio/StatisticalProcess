using StatisticProcess.Domain.Entities;

namespace StatisticProcess.Domain.Entitys
{
    public class MeasurementData : BaseEntity
    {
        public MeasurementData(decimal measurementValue, DateTime measurementDateTime, string deviceCode, string materialCode)
        {
            MeasurementDateTime = measurementDateTime;
            DeviceCode = deviceCode;
        }

        public MeasurementData() { }

        private DateTime measurementDateTime;
        private string deviceCode;
        private List<QuoteData> quotes;

        public DateTime MeasurementDateTime { get => measurementDateTime; set => measurementDateTime = value; }
        public string DeviceCode { get => deviceCode; set => deviceCode = (value ?? "").Trim(); }

        public List<QuoteData> Quotes
        {
            get => quotes;
            set
            {
                if (value == null)
                {
                    quotes = new List<QuoteData>();
                }
                else
                {
                    quotes = value;
                }
            }
        }
    }
}
