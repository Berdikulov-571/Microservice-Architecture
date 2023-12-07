using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Entities.LegalDescriptions;
using Kadastr.Domain.Entities.Owners;
using Kadastr.Domain.Entities.Parcels;
using Kadastr.Domain.Entities.PercalLandUses;
using Kadastr.Domain.Entities.Transactions;
using Kadastr.Service.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.DataAccess.Persistence.DataContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<LandUse> LandUses { get ; set ; }
        public DbSet<LegalDescription> LegalDescriptions { get ; set ; }
        public DbSet<Owner> Owners { get ; set ; }
        public DbSet<Parcel> Parcels { get ; set ; }
        public DbSet<PercalLandUse> PercalLandUses { get ; set ; }
        public DbSet<Transaction> Transactions { get ; set ; }
    }
}