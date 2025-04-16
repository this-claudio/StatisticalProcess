using Microsoft.EntityFrameworkCore;
using StatisticalProcess.Infrastructure.EntityFramework.Context;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Interfaces;

namespace StatisticalProcess.Infrastructure.EntityFramework.Repository
{
    public class MeasurementDataRepository : IMeasurementDataRepository
    {
        private readonly EFContext _context;
        private readonly DbSet<MeasurementData> DbSet;

        public MeasurementDataRepository(EFContext context)
        {
            _context = context;
            DbSet = _context.MeasurementData;
        }

        public async Task<MeasurementData> GetByIdAsync(long id)
        {
            return await DbSet
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<MeasurementData>> GetAllAsync()
        {
            return await DbSet.ToListAsync(); ;
        }

        public async Task<MeasurementData> InsertOneAsync(MeasurementData measurementData)
        {
            await DbSet.AddAsync(measurementData);
            await _context.SaveChangesAsync();
            return measurementData;
        }

        public async Task<MeasurementData> UpdateOneAsync(MeasurementData measurementData)
        {
            DbSet.Update(measurementData);
            await _context.SaveChangesAsync();
            return measurementData;
        }

        public async Task DeleteOneAsync(MeasurementData measurementData)
        {
            measurementData.IsDeleted = true;
            DbSet.Update(measurementData);
            await _context.SaveChangesAsync();
            _context.Entry(measurementData).State = EntityState.Detached;
        }

        public Task<List<MeasurementData>> GetByDevice(string deviceCode, int sampleLenght)
        {
            return DbSet.LoadCollection()
                .Take(sampleLenght)
                .Where(x => x.DeviceCode == deviceCode)
                .OrderByDescending(x => x.MeasurementDateTime).ToListAsync();
        }
    }

    public static class MeasurementDataRepositoryExtensions
    {
        public static IQueryable<MeasurementData> LoadCollection(this DbSet<MeasurementData> dbSet)
        {
            return dbSet
                .Include(x => x.Quotes);
        }
    }
}
