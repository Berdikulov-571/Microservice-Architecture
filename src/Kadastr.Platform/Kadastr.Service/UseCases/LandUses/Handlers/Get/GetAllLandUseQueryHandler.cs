using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Exceptions.LandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LandUses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LandUses.Handlers.Get
{
    public class GetAllLandUseQueryHandler : IRequestHandler<GetAllLandUseQuery, IEnumerable<LandUse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLandUseQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LandUse>> Handle(GetAllLandUseQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.LandUses.ToListAsync(cancellationToken);

            if (result == null)
                throw new LandUseNotFound();

            return result;
        }
    }
}