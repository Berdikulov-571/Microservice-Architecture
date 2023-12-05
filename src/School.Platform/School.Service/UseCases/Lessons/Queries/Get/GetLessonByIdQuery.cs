using MediatR;
using School.Domain.Entities.Lessons;

namespace School.Service.UseCases.Lessons.Queries.Get
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public int LessonId { get; set; }
    }
}