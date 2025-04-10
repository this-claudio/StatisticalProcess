using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticProcess.Domain.Entitys;
using StatisticProcess.Domain.Entities;

namespace StatisticalProcess.Infrastructure.EntityFramework.Configuration
{
    public class QuoteDataConfiguration : IEntityTypeConfiguration<QuoteDate>
    {
        public void Configure(EntityTypeBuilder<QuoteDate> builder)
        {
            
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.measureId);

            builder.HasOne(u => u.Measure)
                .WithMany(u => u.Quotes)
                .HasForeignKey(u => u.measureId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
