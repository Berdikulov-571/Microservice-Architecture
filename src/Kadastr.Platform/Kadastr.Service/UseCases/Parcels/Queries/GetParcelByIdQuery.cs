using Kadastr.Domain.Entities.Parcels;
using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Queries
{
    public class GetParcelByIdQuery : IRequest<Parcel>
    {
        public int ParcelId { get; set; }
    }
}