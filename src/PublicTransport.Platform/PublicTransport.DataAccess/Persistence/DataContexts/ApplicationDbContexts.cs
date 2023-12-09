using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Domain.Entities.Users;
using PublicTransport.Service.Abstractions.DataContexts;

namespace PublicTransport.DataAccess.Persistence.DataContexts
{
    public class ApplicationDbContexts : DbContext, IApplicationDbContext
    {
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options) : base(options) { }

        public DbSet<Driver> Drivers { get ; set ; }
        public DbSet<Payment> Payments { get ; set ; }
        public DbSet<Route> Routes { get ; set ; }
        public DbSet<Schedule> Schedules { get ; set ; }
        public DbSet<Transport> Transports { get ; set ; }
        public DbSet<User> Users { get ; set ; }
    }
}