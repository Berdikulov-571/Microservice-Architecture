using Kadastr.Domain.Dtos.Parcels;
using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Commands.Update
{
    public class ParcelUpdateCommand : ParcelUpdateDto, IRequest<int>
    {

    }
}