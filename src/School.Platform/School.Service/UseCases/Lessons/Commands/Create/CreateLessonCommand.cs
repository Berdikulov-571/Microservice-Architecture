using MediatR;
using School.Domain.Dtos.Lessons;

namespace School.Service.UseCases.Lessons.Commands.Create
{
    public class CreateLessonCommand : LessonCreateDto, IRequest<int>
    {

    }
}