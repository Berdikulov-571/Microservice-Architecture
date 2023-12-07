using Kadastr.Domain.Dtos.Owners;
using MediatR;

namespace Kadastr.Service.UseCases.Owners.Commands.Update
{
    public class UpdateOwnerCommand : OwnerUpdateDto, IRequest<int>
    {
    }
}