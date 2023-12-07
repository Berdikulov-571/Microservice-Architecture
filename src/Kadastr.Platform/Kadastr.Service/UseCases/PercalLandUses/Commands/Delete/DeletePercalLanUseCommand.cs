using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUse.Commands.Delete
{
    public class DeletePercalLanUseCommand : IRequest<int>
    {
        public int PercalLanUse { get; set; }
    }
}