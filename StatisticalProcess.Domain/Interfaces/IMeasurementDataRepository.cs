using StatisticProcess.Domain.Entitys;

namespace StatisticProcess.Domain.Interfaces
{
    public interface IMeasurementDataRepository
    {
        public Task<MeasurementData> GetByIdAsync(long id);
        Task<List<MeasurementData>> GetAllAsync();
        public Task<MeasurementData> InsertOneAsync(MeasurementData measurementData);
        public Task<MeasurementData> UpdateOneAsync(MeasurementData measurementData);
        public Task DeleteOneAsync(MeasurementData measurementData);
        public Task<List<MeasurementData>> GetByDevice(string deviceCode, int sampleLenght);
    }
}
