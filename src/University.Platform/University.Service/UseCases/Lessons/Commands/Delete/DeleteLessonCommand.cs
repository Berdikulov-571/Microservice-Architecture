using MediatR;

namespace University.Service.UseCases.Lessons.Commands.Delete
{
    public class DeleteLessonCommand : IRequest<int>
    {
        public int LessonId { get; set; }
    }
}