using Kadastr.Domain.Dtos.LandUses;
using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Commands.Update
{
    public class UpdateLandUseCommand : LandUseUpdateDto, IRequest<int>
    {

    }
}