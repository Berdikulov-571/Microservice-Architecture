using Kadastr.Domain.Dtos.PercalLandUse;
using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUse.Commands.Create
{
    public class CreatePercalLanUseCommand : PercalLandUseCreateDto, IRequest<int>
    {

    }
}