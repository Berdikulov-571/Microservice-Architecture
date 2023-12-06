using MediatR;
using University.Domain.Entities.Lessons;

namespace University.Service.UseCases.Lessons.Queries.Get
{
    public class GetAllLessonsQuery : IRequest<IEnumerable<Lesson>>
    {
    }
}