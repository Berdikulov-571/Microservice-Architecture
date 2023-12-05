using MediatR;
using School.Domain.Dtos.Task;

namespace School.Service.Abstractions.UseCases.Tasks.Commands.Create
{
    public class CreateTaskCommand : TasksCreateDto, IRequest<int>
    {

    }
}