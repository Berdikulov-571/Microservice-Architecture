using Kadastr.Domain.Exceptions.Parcels;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Parcels.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Parcels.Handlers.Delete
{
    public class DeleteParcelCommandHandler : IRequestHandler<ParcelDeleteCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteParcelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(ParcelDeleteCommand request, CancellationToken cancellationToken)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(x => x.ParcelID == request.ParcelId, cancellationToken);

            if (parcel == null)
                throw new ParcelNotFound();

            _context.Parcels.Remove(parcel);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}