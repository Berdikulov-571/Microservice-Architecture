using MediatR;
using School.Domain.Dtos.Task;

namespace School.Service.UseCases.Tasks.Commands.Update
{
    public class UpdateTaskCommand : TaskUpdateDto, IRequest<int>
    {

    }
}