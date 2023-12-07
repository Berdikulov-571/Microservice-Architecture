using Kadastr.Domain.Entities.LegalDescriptions;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LegalDescriptions.Commands.Create;
using MediatR;

namespace Kadastr.Service.UseCases.LegalDescriptions.Handlers.Create
{
    public class CreateLegalDescriptionCommandHandler : IRequestHandler<CreateLegalDescriptionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLegalDescriptionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLegalDescriptionCommand request, CancellationToken cancellationToken)
        {
            LegalDescription legal = new LegalDescription()
            {
                DescriptionText = request.DescriptionText,
                ParcelID = request.ParcelID,
                CreatedAt = DateTime.Now,
            };

            await _context.LegalDescriptions.AddAsync(legal, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}