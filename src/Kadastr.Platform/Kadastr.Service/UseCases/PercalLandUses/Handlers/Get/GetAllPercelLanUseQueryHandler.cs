using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.PercalLandUses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.PercalLandUses.Handlers.Get
{
    public class GetAllPercelLanUseQueryHandler : IRequestHandler<GetAllPercalLanUseQuery, IEnumerable<Domain.Entities.PercalLandUses.PercalLandUse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPercelLanUseQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.PercalLandUses.PercalLandUse>> Handle(GetAllPercalLanUseQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.PercalLandUses.ToListAsync(cancellationToken);
            
            return result;
        }
    }
}