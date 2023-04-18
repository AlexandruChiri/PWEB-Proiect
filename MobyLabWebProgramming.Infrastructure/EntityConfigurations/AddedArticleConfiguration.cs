using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class AddedArticleConfiguration : BaseEntityConfig1<AddedArticle>
{
    public new void Configure(EntityTypeBuilder<AddedArticle> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Cnt)
            .IsRequired();
        
        builder.HasOne(e => e.Aarticle) // This specifies a one-to-many relation.
            .WithMany() // This provides the reverse mapping for the one-to-many relation. 
            .HasForeignKey(e => e.ArticleId) // Here the foreign key column is specified.
            .HasPrincipalKey(e => e.Id) // This specifies the referenced key in the referenced table.
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
    }
}