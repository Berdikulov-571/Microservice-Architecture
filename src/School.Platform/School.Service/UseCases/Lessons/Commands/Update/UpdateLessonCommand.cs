using MediatR;
using School.Domain.Dtos.Lessons;

namespace School.Service.UseCases.Lessons.Commands.Update
{
    public class UpdateLessonCommand : LessonUpdateDto, IRequest<int>
    {

    }
}