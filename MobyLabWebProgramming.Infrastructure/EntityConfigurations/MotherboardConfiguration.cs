using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class MotherboardConfiguration : ArticleConfiguration<Motherboard>
{
    public new void Configure(EntityTypeBuilder<Motherboard> builder)
    {
        builder.Property(e => e.RamSlots)
            .IsRequired();
        builder.Property(e => e.RamType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.RamCapacity)
            .IsRequired();
        builder.Property(e => e.CpuSocket)
            .HasMaxLength(255)
            .IsRequired();
        base.Configure(builder);
    }
}