using Kadastr.Service.BackGround;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kadastr.Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHostedService<BaseBackGroundService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "Kadastr";
                options.Configuration = "127.0.0.1:6379";
            });

            return services;
        }
    }
}
