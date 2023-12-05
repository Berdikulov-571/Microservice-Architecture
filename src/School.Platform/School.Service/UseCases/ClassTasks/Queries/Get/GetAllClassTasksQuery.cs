using MediatR;
using School.Domain.Entities.ClassTasks;
using School.Domain.Entities.Teachers;

namespace School.Service.UseCases.ClassTasks.Queries.Get
{
    public class GetAllClassTasksQuery : IRequest<IEnumerable<Teacher>>
    {

    }
}