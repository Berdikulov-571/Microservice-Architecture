using Kadastr.Domain.Entities.Owners;
using Kadastr.Domain.Exceptions.Owners;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Owners.Handlers.Get
{
    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, Owner>
    {
        private readonly IApplicationDbContext _context;

        public GetOwnerByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            Owner? owner = await _context.Owners.FirstOrDefaultAsync(x => x.OwnerID == request.OwnerId,cancellationToken);

            if (owner == null)
                throw new OwnerNotFound();

            return owner;
        }
    }
}