using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Entities.LegalDescriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Kadastr.DataAccess.Persistence.EntityTypeConfigurations.LegalDescriptions
{
    public class LegalDescriptionEntityTypeConfiguration : IEntityTypeConfiguration<LegalDescription>
    {
        public void Configure(EntityTypeBuilder<LegalDescription> builder)
        {
            builder.HasOne(ld => ld.Parcel);
        }
    }
}