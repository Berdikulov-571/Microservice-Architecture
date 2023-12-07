using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Exceptions.LandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LandUses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LandUses.Handlers.Get
{
    public class GetLandUseByIdQueryHandler : IRequestHandler<GetLandUseByIdQuery, LandUse>
    {
        private readonly IApplicationDbContext _context;

        public GetLandUseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LandUse> Handle(GetLandUseByIdQuery request, CancellationToken cancellationToken)
        {
            var landUse = await _context.LandUses.FirstOrDefaultAsync(x => x.LandUseID == request.LandUseId, cancellationToken);

            if (landUse == null)
                throw new LandUseNotFound();

            return landUse;
        }
    }
}