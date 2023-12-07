using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUses.Queries
{
    public class GetAllPercalLanUseQuery : IRequest<IEnumerable<Kadastr.Domain.Entities.PercalLandUses.PercalLandUse>>
    {

    }
}