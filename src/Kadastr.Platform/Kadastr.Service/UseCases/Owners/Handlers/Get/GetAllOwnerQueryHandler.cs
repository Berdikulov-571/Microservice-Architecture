using Kadastr.Domain.Entities.Owners;
using Kadastr.Domain.Exceptions.Owners;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Kadastr.Service.UseCases.Owners.Handlers.Get
{
    public class GetAllOwnerQueryHandler : IRequestHandler<GetAllOwnerQuery, IEnumerable<Owner>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _cache;

        public GetAllOwnerQueryHandler(IApplicationDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Owner>> Handle(GetAllOwnerQuery request, CancellationToken cancellationToken)
        {
            string? response = _cache.GetString("GetAllOwners");

            if (response != null)
            {
                var cacheStudents = JsonConvert.DeserializeObject<List<Owner>>(response);

                return cacheStudents;
            }

            var owners = await _context.Owners.ToListAsync(cancellationToken);

            if (owners == null)
                throw new OwnerNotFound();

            return owners;
        }
    }
}