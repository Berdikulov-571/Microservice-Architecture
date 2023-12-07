using Kadastr.Domain.Dtos.Parcels;
using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Commands.Create
{
    public class ParcelCreateCommand : ParcelCreateDto, IRequest<int>
    {
    }
}