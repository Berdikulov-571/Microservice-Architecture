using MediatR;
using University.Domain.Dtos.Groups;

namespace University.Service.UseCases.Groups.Commands.Update
{
    public class UpdateGroupCommand : GroupUpdateDto, IRequest<int>
    {

    }
}