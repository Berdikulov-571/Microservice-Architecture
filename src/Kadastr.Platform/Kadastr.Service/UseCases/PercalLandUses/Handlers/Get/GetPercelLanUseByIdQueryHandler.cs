using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.PercalLandUses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.PercalLandUses.Handlers.Get
{
    public class GetPercelLanUseByIdQueryHandler : IRequestHandler<GetPercelLanUseByIdQuery, Domain.Entities.PercalLandUses.PercalLandUse>
    {
        private readonly IApplicationDbContext _context;

        public GetPercelLanUseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.PercalLandUses.PercalLandUse> Handle(GetPercelLanUseByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.PercalLandUses.FirstOrDefaultAsync(x => x.ParcelLandUseID == request.PercelLanUseId, cancellationToken);

            return result;
        }
    }
}