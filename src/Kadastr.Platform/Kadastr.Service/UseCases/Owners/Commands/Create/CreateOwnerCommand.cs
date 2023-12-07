using Kadastr.Domain.Dtos.Owners;
using MediatR;

namespace Kadastr.Service.UseCases.Owners.Commands.Create
{
    public class CreateOwnerCommand : OwnerCreateDto, IRequest<int>
    {

    }
}