using Kadastr.Domain.Entities.Parcels;
using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Queries
{
    public class GetAllParcelsQuery : IRequest<IEnumerable<Parcel>>
    {

    }
}