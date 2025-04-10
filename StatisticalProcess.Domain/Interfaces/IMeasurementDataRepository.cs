using StatisticProcess.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticProcess.Domain.Interfaces
{
    public interface IMeasurementDataRepository
    {
        public Task<MeasurementData> GetByIdAsync(long id);
        Task<List<MeasurementData>> GetAllAsync();
        public Task<MeasurementData> InsertOneAsync(MeasurementData measurementData);
        public Task<MeasurementData> UpdateOneAsync(MeasurementData measurementData);
        public Task DeleteOneAsync(MeasurementData measurementData);
    }
}
