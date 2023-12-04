
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Service.Interfaces.File;
using School.Service.Service.Files;
using System.Reflection;

namespace School.Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
