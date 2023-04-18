using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class RamConfiguration : ArticleConfiguration<Ram>
{
    public new void Configure(EntityTypeBuilder<Ram> builder)
    {
        builder.Property(e => e.Frequency)
            .IsRequired();
        builder.Property(e => e.Capacity)
            .IsRequired();
        builder.Property(e => e.RamType)
            .HasMaxLength(255)
            .IsRequired();
        base.Configure(builder);
    }
}