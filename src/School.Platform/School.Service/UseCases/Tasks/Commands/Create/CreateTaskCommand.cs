using MediatR;
using School.Domain.Dtos.Task;

namespace School.Service.UseCases.Tasks.Commands.Create
{
    public class CreateTaskCommand : TasksCreateDto, IRequest<int>
    {

    }
}