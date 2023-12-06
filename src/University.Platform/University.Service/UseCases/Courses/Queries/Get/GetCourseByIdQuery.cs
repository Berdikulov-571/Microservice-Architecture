using MediatR;
using University.Domain.Entities.Courses;

namespace University.Service.UseCases.Courses.Queries.Get
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int CourseId { get; set; }
    }
}