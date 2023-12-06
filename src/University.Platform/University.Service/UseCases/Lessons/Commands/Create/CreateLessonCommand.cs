using MediatR;
using University.Domain.Dtos.Lessons;

namespace University.Service.UseCases.Lessons.Commands.Create
{
    public class CreateLessonCommand : LessonCreateDto, IRequest<int>
    {

    }
}