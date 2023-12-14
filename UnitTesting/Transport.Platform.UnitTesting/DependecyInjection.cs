using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PublicTransport.Service.Abstractions.DataContexts;

namespace Transport.Platform.UnitTesting
{
    public class DependecyInjection
    {
        public IServiceProvider ServiceProvider { get; set; }

        public DependecyInjection()
        {
            IServiceCollection service = new ServiceCollection();

            service.AddDbContext<IApplicationDbContext, FakeDbContext>(options => options.UseInMemoryDatabase("FakeDbContext"));

            ServiceProvider = service.BuildServiceProvider();
        }
    }
}