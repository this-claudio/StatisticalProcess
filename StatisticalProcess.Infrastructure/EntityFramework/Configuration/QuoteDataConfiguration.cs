using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticProcess.Domain.Entities;

namespace StatisticalProcess.Infrastructure.EntityFramework.Configuration
{
    public class QuoteDataConfiguration : IEntityTypeConfiguration<QuoteData>
    {
        public void Configure(EntityTypeBuilder<QuoteData> builder)
        {

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.measureId);

            builder.Property(x => x.value)
                .HasPrecision(18, 4);

            builder.HasOne(u => u.Measure)
                .WithMany(u => u.Quotes)
                .HasForeignKey(u => u.measureId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
