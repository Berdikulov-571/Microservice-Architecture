using Kadastr.Domain.Entities.Owners;
using Kadastr.Domain.Exceptions.Owners;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Owners.Handlers.Get
{
    public class GetAllOwnerQueryHandler : IRequestHandler<GetAllOwnerQuery, IEnumerable<Owner>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOwnerQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Owner>> Handle(GetAllOwnerQuery request, CancellationToken cancellationToken)
        {
            var owners = await _context.Owners.ToListAsync(cancellationToken);

            if (owners == null)
                throw new OwnerNotFound();

            return owners;
        }
    }
}