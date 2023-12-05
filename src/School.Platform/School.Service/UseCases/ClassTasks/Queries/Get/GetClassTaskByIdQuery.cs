using MediatR;
using School.Domain.Entities.ClassTasks;
using School.Domain.Entities.Teachers;

namespace School.Service.UseCases.ClassTasks.Queries.Get
{
    public class GetClassTaskByIdQuery : IRequest<List<Teacher>>
    {
        public int TeacherId { get; set; }
    }
}