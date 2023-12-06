using MediatR;
using University.Domain.Dtos.Lessons;

namespace University.Service.UseCases.Lessons.Commands.Update
{
    public class UpdateLessonCommand : LessonUpdateDto, IRequest<int>
    {
    }
}