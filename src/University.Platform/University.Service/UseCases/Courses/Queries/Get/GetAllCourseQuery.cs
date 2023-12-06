using MediatR;
using University.Domain.Entities.Courses;

namespace University.Service.UseCases.Courses.Queries.Get
{
    public class GetAllCourseQuery : IRequest<IEnumerable<Course>>
    {

    }
}