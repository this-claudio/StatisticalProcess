using Microsoft.EntityFrameworkCore;
using StatisticalProcess.Infrastructure.EntityFramework.Configuration;
using StatisticProcess.Domain.Entitys;

namespace StatisticalProcess.Infrastructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public DbSet<MeasurementData> MeasurementData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(nameof(StatisticalProcess));

            modelBuilder.ApplyConfiguration(new MeasurementDataConfiguration());

            modelBuilder.Entity<MeasurementData>()
                    .HasQueryFilter(m => !m.IsDeleted);
        }
    }
    

    
}
