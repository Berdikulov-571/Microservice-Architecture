using Kadastr.Domain.Entities.LandUses;
using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Queries
{
    public class GetAllLandUseQuery : IRequest<IEnumerable<LandUse>>
    {

    }
}