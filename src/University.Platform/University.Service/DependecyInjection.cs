using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using University.Service.Interfaces.File;
using University.Service.Service.Files;

namespace University.Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IFileService, FileService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "Redis";
                options.Configuration = "127.0.0.1:6379";
            });

            return services;
        }
    }
}