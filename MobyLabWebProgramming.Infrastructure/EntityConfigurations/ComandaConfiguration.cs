using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class ComandaConfiguration : BaseEntityConfig1<Comanda>
{
    public new void Configure(EntityTypeBuilder<Comanda> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.User)
            .IsRequired();
        builder.Property(e => e.UserId)
            .IsRequired();
        
        builder.HasMany(e => e.PurchasedArticles) // This specifies a many-to-one relation.
            .WithOne() // This provides the reverse mapping for the many-to-one relation. 
            .HasForeignKey(e => e.ComandaId) // Here the foreign key column is specified.
            .HasPrincipalKey(e => e.Id) // This specifies the referenced key in the referenced table.
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
        
        builder.HasOne(e => e.User) // This specifies a one-to-one relation.
            .WithMany(x => x.Comenzi) // This provides the reverse mapping for the one-to-one relation. 
            .HasForeignKey(e => e.UserId) // Here the foreign key column is specified.
            .HasPrincipalKey(e => e.Id) // This specifies the referenced key in the referenced table.
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
    }
}