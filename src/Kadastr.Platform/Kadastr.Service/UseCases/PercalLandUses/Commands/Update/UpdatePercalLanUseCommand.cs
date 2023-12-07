using Kadastr.Domain.Dtos.PercalLandUse;
using MediatR;

namespace Kadastr.Service.UseCases.PercalLandUse.Commands.Update
{
    public class UpdatePercalLanUseCommand : PercalLandUseUpdateDto, IRequest<int>
    {

    }
}