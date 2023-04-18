using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class CpuConfiguration : ArticleConfiguration<Cpu>
{
    public new void Configure(EntityTypeBuilder<Cpu> builder)
    {
        builder.Property(e => e.Frequency)
            .IsRequired();
        builder.Property(e => e.Cores)
            .IsRequired();
        builder.Property(e => e.Threads)
            .IsRequired();
        builder.Property(e => e.Tdp)
            .IsRequired();
        builder.Property(e => e.Socket)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.Igpu)
            .IsRequired();
        base.Configure(builder);
    }
}