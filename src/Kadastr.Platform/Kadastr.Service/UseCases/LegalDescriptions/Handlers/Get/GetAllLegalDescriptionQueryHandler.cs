using Kadastr.Domain.Entities.LegalDescriptions;
using Kadastr.Domain.Exceptions.LegalDescription;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.LegalDescriptions.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.LegalDescriptions.Handlers.Get
{
    public class GetAllLegalDescriptionQueryHandler : IRequestHandler<GetAllLegalDescriptionQuery, IEnumerable<LegalDescription>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLegalDescriptionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LegalDescription>> Handle(GetAllLegalDescriptionQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.LegalDescriptions.ToListAsync(cancellationToken);

            if (result == null)
                throw new LegalDescriptionNotFound();

            return result;
        }
    }
}