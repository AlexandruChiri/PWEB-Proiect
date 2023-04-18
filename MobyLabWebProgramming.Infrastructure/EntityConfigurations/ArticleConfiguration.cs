using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class ArticleConfiguration : BaseEntityConfig1<Article>
{
    public new void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name)
            .HasMaxLength(255) // This specifies the maximum length for varchar type in the database.
            .IsRequired();
        builder.Property(e => e.Type)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(5000)
            .IsRequired();
        builder.HasAlternateKey(e => e.Name); // Here it is specifies that the property Name is a unique key.
        builder.Property(e => e.Manufacturer)
            .HasMaxLength(255)
            .IsRequired();
    }
}
