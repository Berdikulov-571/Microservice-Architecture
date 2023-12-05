using MediatR;

namespace School.Service.Abstractions.UseCases.Tasks.Queries.Get
{
    public class GetTaskByIdQuery : IRequest<School.Domain.Entities.Task.Tasks>
    {
        public int TaskId { get; set; }
    }
}