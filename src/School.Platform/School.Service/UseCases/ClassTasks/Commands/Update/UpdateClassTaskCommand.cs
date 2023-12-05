using MediatR;
using School.Domain.Dtos.ClassTasks;

namespace School.Service.UseCases.ClassTasks.Commands.Update
{
    public class UpdateClassTaskCommand : ClassTaskUpdateDto, IRequest<int>
    {

    }
}