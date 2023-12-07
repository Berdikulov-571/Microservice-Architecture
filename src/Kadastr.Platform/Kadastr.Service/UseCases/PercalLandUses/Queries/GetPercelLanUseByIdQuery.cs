using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUses.Queries
{
    public class GetPercelLanUseByIdQuery : IRequest<Kadastr.Domain.Entities.PercalLandUses.PercalLandUse>
    {
        public int PercelLanUseId { get; set; }
    }
}