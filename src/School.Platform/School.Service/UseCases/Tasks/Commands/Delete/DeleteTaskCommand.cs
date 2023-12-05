using MediatR;

namespace School.Service.UseCases.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest<int>
    {
        public int TaskId { get; set; }
    }
}