using MediatR;

namespace School.Service.UseCases.Tasks.Queries.Get
{
    public class GetTaskByIdQuery : IRequest<Domain.Entities.Task.Tasks>
    {
        public int TaskId { get; set; }
    }
}