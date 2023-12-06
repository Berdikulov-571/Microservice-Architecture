using MediatR;

namespace University.Service.UseCases.Courses.Commands.Delete
{
    public class DeleteCourseCommand : IRequest<int>
    {
        public int CourseId { get; set; }
    }
}