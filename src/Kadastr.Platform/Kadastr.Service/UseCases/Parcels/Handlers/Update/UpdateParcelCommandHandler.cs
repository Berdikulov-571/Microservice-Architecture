using Kadastr.Domain.Exceptions.Parcels;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Parcels.Commands.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Parcels.Handlers.Update
{
    public class UpdateParcelCommandHandler : IRequestHandler<ParcelUpdateCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateParcelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(ParcelUpdateCommand request, CancellationToken cancellationToken)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(x => x.ParcelID == request.ParcelID,cancellationToken);

            if (parcel == null)
                throw new ParcelNotFound();

            parcel.Area = request.Area;
            parcel.OwnerID = request.OwnerID;
            parcel.UpdatedAt = DateTime.Now;
            parcel.ParcelNumber = request.ParcelNumber;

            _context.Parcels.Update(parcel);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}