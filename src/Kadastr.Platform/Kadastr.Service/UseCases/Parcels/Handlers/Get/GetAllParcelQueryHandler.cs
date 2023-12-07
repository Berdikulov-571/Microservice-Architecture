using Kadastr.Domain.Entities.Parcels;
using Kadastr.Domain.Exceptions.Parcels;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Parcels.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Parcels.Handlers.Get
{
    public class GetAllParcelQueryHandler : IRequestHandler<GetAllParcelsQuery, IEnumerable<Parcel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllParcelQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parcel>> Handle(GetAllParcelsQuery request, CancellationToken cancellationToken)
        {
            var parcels = await _context.Parcels.ToListAsync(cancellationToken);

            if (parcels == null)
                throw new ParcelNotFound();

            return parcels;
        }
    }
}