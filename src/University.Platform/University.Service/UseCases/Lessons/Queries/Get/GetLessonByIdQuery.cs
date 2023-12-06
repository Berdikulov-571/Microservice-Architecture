using MediatR;
using University.Domain.Entities.Lessons;

namespace University.Service.UseCases.Lessons.Queries.Get
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public int LessonId { get; set; }
    }
}