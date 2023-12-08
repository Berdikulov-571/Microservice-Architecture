using Kadastr.Domain.Entities.Parcels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kadastr.DataAccess.Persistence.EntityTypeConfigurations.Parcels
{
    public class ParcelEntityTypeConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasOne(p => p.Owner)
            .WithMany(o => o.Parcels)
            .HasForeignKey(p => p.OwnerID);
        }
    }
}