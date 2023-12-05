using MediatR;

namespace School.Service.UseCases.Lessons.Commands.Delete
{
    public class DeleteLessonCommand : IRequest<int>
    {
        public int LessonId { get; set; }
    }
}