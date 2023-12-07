using Kadastr.Domain.Entities.Parcels;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Parcels.Commands.Create;
using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Handlers.Create
{
    public class CreateParcelCommandHandler : IRequestHandler<ParcelCreateCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateParcelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(ParcelCreateCommand request, CancellationToken cancellationToken)
        {
            Parcel parcel = new Parcel()
            {
                Area = request.Area,
                OwnerID = request.OwnerID,
                CreatedAt = DateTime.Now,
                ParcelNumber = request.ParcelNumber,
            };

            await _context.Parcels.AddAsync(parcel,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}