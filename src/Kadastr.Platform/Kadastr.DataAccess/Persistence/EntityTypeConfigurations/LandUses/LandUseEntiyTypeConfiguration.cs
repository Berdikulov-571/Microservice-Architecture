using Kadastr.Domain.Entities.LandUses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kadastr.DataAccess.Persistence.EntityTypeConfigurations.LandUses
{
    public class LandUseEntiyTypeConfiguration : IEntityTypeConfiguration<LandUse>
    {
        public void Configure(EntityTypeBuilder<LandUse> builder)
        {
            builder.HasKey(x => x.LandUseID);
        }
    }
}