using Kadastr.Domain.Entities.LandUses;
using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Queries
{
    public class GetLandUseByIdQuery : IRequest<LandUse>
    {
        public int LandUseId { get; set; }
    }
}