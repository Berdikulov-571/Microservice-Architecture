using Autorization.Api.DataContexts;
using Autorization.Api.Interfaces;
using Autorization.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace University.Platform.UnitTesting
{
    public class DependecyInjection
    {
        public IServiceProvider ServiceProvider { get; set; }

        public DependecyInjection()
        {
            IServiceCollection service = new ServiceCollection();

            //service.AddDbContext<IApplicationDbContext, FakeDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("FakeDbContext");
            //});

            service.AddScoped<IAuthService, AuthService>();

            service.AddDbContext<SchoolDatabase>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=School.Platform;Trusted_Connection=True;TrustServerCertificate=True;"));
            service.AddDbContext<UniversityDatabase>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=University.Platform;Trusted_Connection=True;TrustServerCertificate=True;"));


            ServiceProvider = service.BuildServiceProvider();
        }
    }
}