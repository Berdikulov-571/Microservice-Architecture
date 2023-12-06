using MediatR;
using University.Domain.Dtos.Groups;

namespace University.Service.UseCases.Groups.Commands.Create
{
    public class CreateGroupCommand : GroupCreateDto, IRequest<int>
    {

    }
}