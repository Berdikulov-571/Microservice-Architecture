using MediatR;
using School.Domain.Entities.Lessons;

namespace School.Service.UseCases.Lessons.Queries.Get
{
    public class GetAllLessonQuery : IRequest<IEnumerable<Lesson>>
    {

    }
}