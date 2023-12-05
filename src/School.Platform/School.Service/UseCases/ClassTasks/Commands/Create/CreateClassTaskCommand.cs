using MediatR;
using School.Domain.Dtos.ClassTasks;

namespace School.Service.UseCases.ClassTasks.Commands.Create
{
    public class CreateClassTaskCommand : ClassTasksCreateDto, IRequest<int>
    {

    }
}