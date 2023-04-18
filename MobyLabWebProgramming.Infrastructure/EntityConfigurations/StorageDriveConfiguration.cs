using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class StorageDriveConfiguration : ArticleConfiguration<StorageDrive>
{
    public new void Configure(EntityTypeBuilder<StorageDrive> builder)
    {
        builder.Property(e => e.DriveType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.Capacity)
            .IsRequired();
        builder.Property(e => e.Interface)
            .HasMaxLength(255)
            .IsRequired();
        base.Configure(builder);
    }
}