using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Domain.Entities.Users;

namespace PublicTransport.Service.Abstractions.DataContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Driver> Drivers { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Route> Routes { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Transport> Transports { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}