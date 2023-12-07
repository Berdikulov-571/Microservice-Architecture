using Kadastr.Domain.Exceptions.LandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LandUses.Commands.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LandUses.Handlers.Update
{
    public class UpdateLandUseCommandHandler : IRequestHandler<UpdateLandUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLandUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateLandUseCommand request, CancellationToken cancellationToken)
        {
            var landUse = await _context.LandUses.FirstOrDefaultAsync(x => x.LandUseID == request.LandUseID, cancellationToken);

            if (landUse == null)
                throw new LandUseNotFound();

            landUse.LandUseType = request.LandUseType;
            landUse.UpdatedAt = DateTime.Now;

            _context.LandUses.Update(landUse);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}   