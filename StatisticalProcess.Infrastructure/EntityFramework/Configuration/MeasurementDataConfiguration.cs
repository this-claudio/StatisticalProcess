using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticProcess.Domain.Entitys;

namespace StatisticalProcess.Infrastructure.EntityFramework.Configuration
{
    public class MeasurementDataConfiguration : IEntityTypeConfiguration<MeasurementData>
    {
        public void Configure(EntityTypeBuilder<MeasurementData> builder)
        {
            
            builder.HasKey(u => u.Id); 

            builder.Property(u => u.DeviceCode)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.MaterialCode)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.MeasurementValue)
                .HasPrecision(18, 4);

        }
    }
}
