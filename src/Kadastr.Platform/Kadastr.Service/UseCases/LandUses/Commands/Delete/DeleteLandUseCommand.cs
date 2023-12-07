using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Commands.Delete
{
    public class DeleteLandUseCommand : IRequest<int>
    {
        public int LandUseId { get; set; }
    }
}