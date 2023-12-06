using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.DataAccess.Persistence.DataContexts;
using University.Service.Abstractions.DataContexts;

namespace University.DataAccess
{
    public static class DependesyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}