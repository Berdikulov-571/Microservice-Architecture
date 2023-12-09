using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicTransport.DataAccess.Persistence.DataContexts;
using PublicTransport.Service.Abstractions.DataContexts;


namespace PublicTransport.DataAccess
{
    public static class DependesyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContexts>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            return services;
        }
    }
}