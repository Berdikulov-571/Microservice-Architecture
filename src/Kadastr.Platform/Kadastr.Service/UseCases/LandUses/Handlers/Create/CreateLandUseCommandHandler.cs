using Kadastr.Domain.Entities.LandUses;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LandUses.Commands.Create;
using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Handlers.Create
{
    public class CreateLandUseCommandHandler : IRequestHandler<CreateLandUseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLandUseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLandUseCommand request, CancellationToken cancellationToken)
        {
            LandUse landUse = new LandUse()
            {
                LandUseType = request.LandUseType,
                CreatedAt = DateTime.Now
            };

            await _context.LandUses.AddAsync(landUse,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}