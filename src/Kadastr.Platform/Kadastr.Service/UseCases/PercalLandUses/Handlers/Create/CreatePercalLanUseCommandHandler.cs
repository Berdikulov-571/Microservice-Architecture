using Kadastr.Domain.Entities.PercalLandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.PercalLandUse.Commands.Create;
using Kadastr.Service.UseCases.PercalLandUses.Queries;
using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUses.Handlers.Create
{
    public class CreatePercalLanUseCommandHandler : IRequestHandler<CreatePercalLanUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePercalLanUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePercalLanUseCommand request, CancellationToken cancellationToken)
        {
            Kadastr.Domain.Entities.PercalLandUses.PercalLandUse percel = new Domain.Entities.PercalLandUses.PercalLandUse()
            {
                CreatedAt = DateTime.Now,
                ParcelID = request.ParcelID,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LandUseID = request.LandUseID,
            };

            await _context.PercalLandUses.AddAsync(percel,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}