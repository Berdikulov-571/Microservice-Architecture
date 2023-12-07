using Kadastr.Domain.Dtos.LandUses;
using MediatR;

namespace Kadastr.Service.UseCases.LandUses.Commands.Create
{
    public class CreateLandUseCommand : LandUseCreateDto, IRequest<int>
    {

    }
}