using Kadastr.Domain.Entities.Parcels;
using Kadastr.Domain.Exceptions.Parcels;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Parcels.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Parcels.Handlers.Get
{
    public class GetParcelByIdQueryHandler : IRequestHandler<GetParcelByIdQuery, Parcel>
    {
        private readonly IApplicationDbContext _context;

        public GetParcelByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Parcel> Handle(GetParcelByIdQuery request, CancellationToken cancellationToken)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(x => x.ParcelID == request.ParcelId, cancellationToken);

            if (parcel == null)
                throw new ParcelNotFound();
            
            return parcel;
        }
    }
}