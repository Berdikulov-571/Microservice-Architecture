using Kadastr.Domain.Exceptions.LandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LandUses.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LandUses.Handlers.Delete
{
    public class DeleteLandUseCommandHandler : IRequestHandler<DeleteLandUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLandUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteLandUseCommand request, CancellationToken cancellationToken)
        {
            var landUse = await _context.LandUses.FirstOrDefaultAsync(x => x.LandUseID == request.LandUseId, cancellationToken);

            if (landUse == null)
                throw new LandUseNotFound();

            _context.LandUses.Remove(landUse);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}