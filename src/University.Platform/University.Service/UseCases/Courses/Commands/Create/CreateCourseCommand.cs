using MediatR;
using University.Domain.Dtos.Courses;

namespace University.Service.UseCases.Courses.Commands.Create
{
    public class CreateCourseCommand : CourseCreateDto, IRequest<int>
    {

    }
}