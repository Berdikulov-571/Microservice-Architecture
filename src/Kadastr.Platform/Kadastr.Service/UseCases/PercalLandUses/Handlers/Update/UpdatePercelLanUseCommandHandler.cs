using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.PercalLandUse.Commands.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.PercalLandUses.Handlers.Update
{
    public class UpdatePercelLanUseCommandHandler : IRequestHandler<UpdatePercalLanUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePercelLanUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdatePercalLanUseCommand request, CancellationToken cancellationToken)
        {
            var percal = await _context.PercalLandUses.FirstOrDefaultAsync(x => x.ParcelLandUseID == request.ParcelLandUseID, cancellationToken);

            if (percal == null)
            {
                return 0;
            }
            
            percal.UpdatedAt = DateTime.Now;
            percal.ParcelID = request.ParcelID;
            percal.StartDate = request.StartDate;
            percal.EndDate = request.EndDate;
            percal.LandUseID = request.LandUseID;

            _context.PercalLandUses.Update(percal);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}