using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Entities.LegalDescriptions;
using Kadastr.Domain.Entities.Owners;
using Kadastr.Domain.Entities.Parcels;
using Kadastr.Domain.Entities.PercalLandUses;
using Kadastr.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<LandUse> LandUses { get; set; }
        DbSet<LegalDescription> LegalDescriptions { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<Parcel> Parcels { get; set; }
        DbSet<PercalLandUse> PercalLandUses { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}