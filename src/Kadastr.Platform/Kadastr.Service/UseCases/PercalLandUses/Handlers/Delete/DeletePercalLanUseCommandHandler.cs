using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.PercalLandUse.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.PercalLandUses.Handlers.Delete
{
    public class DeletePercalLanUseCommandHandler : IRequestHandler<DeletePercalLanUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeletePercalLanUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeletePercalLanUseCommand request, CancellationToken cancellationToken)
        {
            var percel = await _context.PercalLandUses.FirstOrDefaultAsync(x => x.ParcelLandUseID == request.PercalLanUse);

            if(percel == null)
            {
                return 0;
            }

            _context.PercalLandUses.Remove(percel);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}