using Kadastr.Domain.Entities.PercalLandUses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kadastr.DataAccess.Persistence.EntityTypeConfigurations.PercalLandUses
{
    public class PercalLandUseEntityTypeConfiguration : IEntityTypeConfiguration<PercalLandUse>
    {
        public void Configure(EntityTypeBuilder<PercalLandUse> builder)
        {
            builder.HasKey(x => x.ParcelLandUseID);
        }
    }
}