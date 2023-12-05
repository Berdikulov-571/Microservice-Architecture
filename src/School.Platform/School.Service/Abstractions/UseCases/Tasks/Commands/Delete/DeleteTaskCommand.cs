using MediatR;

namespace School.Service.Abstractions.UseCases.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest<int>
    {
        public int TaskId { get; set; }
    }
}