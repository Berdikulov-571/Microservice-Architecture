using MediatR;

namespace School.Service.UseCases.ClassTasks.Commands.Delete
{
    public class DeleteClassTaskCommand : IRequest<int>
    {
        public int ClassTaskId { get; set; }
    }
}