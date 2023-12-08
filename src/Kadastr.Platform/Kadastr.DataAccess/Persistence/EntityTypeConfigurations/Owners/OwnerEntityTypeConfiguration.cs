using Kadastr.Domain.Entities.Owners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kadastr.DataAccess.Persistence.EntityTypeConfigurations.Owners
{
    public class OwnerEntityTypeConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasMany(o => o.Parcels)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerID);
        }
    }
}
