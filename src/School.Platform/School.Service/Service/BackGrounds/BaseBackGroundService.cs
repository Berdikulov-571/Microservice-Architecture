using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using School.Service.Abstractions.DataAccess;

namespace School.Service.Service.BackGrounds
{
    public class BaseBackGroundService : BackgroundService
    {
        private readonly IDistributedCache _cache;
        private readonly IServiceProvider _serviceProvider;

        public BaseBackGroundService(IDistributedCache cache, IServiceProvider serviceProvider)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            PeriodicTimer? perroit = new PeriodicTimer(TimeSpan.FromSeconds(10));

            while (await perroit.WaitForNextTickAsync(stoppingToken))
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

                    var result = await dbContext.Students.ToListAsync();

                    if (result.Count > 0)
                    {
                        _cache.SetString("GetAllStudents", JsonConvert.SerializeObject(result));
                    }
                }
            }
        }
    }
}