using StatisticProcess.Domain.Entitys;

namespace StatisticProcess.Domain.Entities
{
    public class QuoteDate : BaseEntity
    {
        public QuoteDate(decimal value)
        {
            Value = value;
        }

        public QuoteDate() { }

        private decimal Value { get; set; }
        private long MeasureId { get; set; }

        public decimal value { get => Value; set => Value = value; }
        public long measureId { get => MeasureId; set => MeasureId = value; }


        public MeasurementData Measure { get; set; }
    }
}