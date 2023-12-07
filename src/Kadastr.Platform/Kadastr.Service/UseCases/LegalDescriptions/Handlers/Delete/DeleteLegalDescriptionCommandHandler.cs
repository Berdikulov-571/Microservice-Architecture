using Kadastr.Domain.Exceptions.LegalDescription;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LegalDescriptions.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LegalDescriptions.Handlers.Delete
{
    public class DeleteLegalDescriptionCommandHandler : IRequestHandler<DeleteLegalDescriptionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLegalDescriptionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteLegalDescriptionCommand request, CancellationToken cancellationToken)
        {
            var legalDescription = await _context.LegalDescriptions.FirstOrDefaultAsync(x => x.LegalDescriptionID == request.LegalDescriptionId, cancellationToken);

            if (legalDescription == null)
                throw new LegalDescriptionNotFound();

            _context.LegalDescriptions.Remove(legalDescription);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}