using MediatR;
using School.Domain.Dtos.Task;

namespace School.Service.Abstractions.UseCases.Tasks.Commands.Update
{
    public class UpdateTaskCommand : TaskUpdateDto, IRequest<int>
    {

    }
}