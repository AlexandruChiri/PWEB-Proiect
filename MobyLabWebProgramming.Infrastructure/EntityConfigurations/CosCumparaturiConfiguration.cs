using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class CosCumparaturiConfiguration : BaseEntityConfig1<CosCumparaturi>
{
    public new void Configure(EntityTypeBuilder<CosCumparaturi> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.User)
            .IsRequired();
        builder.Property(e => e.UserId)
            .IsRequired();
        
        builder.HasMany(e => e.Articles) // This specifies a many-to-one relation.
            .WithOne() // This provides the reverse mapping for the many-to-one relation. 
            .HasForeignKey(e => e.CosId) // Here the foreign key column is specified.
            .HasPrincipalKey(e => e.Id) // This specifies the referenced key in the referenced table.
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
        
        builder.HasOne(e => e.User) // This specifies a one-to-one relation.
            .WithOne(x => x.Cos) // This provides the reverse mapping for the one-to-one relation. 
            .HasForeignKey<CosCumparaturi>(e => e.UserId) // Here the foreign key column is specified.
            .HasPrincipalKey<User>(e => e.Id) // This specifies the referenced key in the referenced table.
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
    }
}