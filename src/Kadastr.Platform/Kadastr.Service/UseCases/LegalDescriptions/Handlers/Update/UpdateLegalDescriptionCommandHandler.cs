using Kadastr.Domain.Exceptions.LegalDescription;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LegalDescriptions.Commands.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LegalDescriptions.Handlers.Update
{
    public class UpdateLegalDescriptionCommandHandler : IRequestHandler<UpdateLegalDescriptionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLegalDescriptionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateLegalDescriptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.LegalDescriptions.FirstOrDefaultAsync(x => x.LegalDescriptionID == request.LegalDescriptionId, cancellationToken);

            if (result == null)
                throw new LegalDescriptionNotFound();

            result.UpdatedAt = DateTime.Now;
            result.DescriptionText = request.DescriptionText;
            result.ParcelID = request.ParcelID;

            _context.LegalDescriptions.Update(result);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}