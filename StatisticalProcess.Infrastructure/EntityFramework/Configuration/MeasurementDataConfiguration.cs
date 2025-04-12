using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticProcess.Domain.Entitys;

namespace StatisticalProcess.Infrastructure.EntityFramework.Configuration
{
    public class MeasurementDataConfiguration : IEntityTypeConfiguration<MeasurementData>
    {
        public void Configure(EntityTypeBuilder<MeasurementData> builder)
        {

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.MeasurementDateTime);

            builder.Property(u => u.DeviceCode)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
