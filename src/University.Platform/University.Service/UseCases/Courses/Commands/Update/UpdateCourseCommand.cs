using MediatR;
using University.Domain.Dtos.Courses;

namespace University.Service.UseCases.Courses.Commands.Update
{
    public class UpdateCourseCommand : CourseUpdateDto, IRequest<int>
    {

    }
}