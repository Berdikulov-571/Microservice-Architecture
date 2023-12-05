using MediatR;

namespace School.Service.UseCases.Teachers.Commands.Delete
{
    public class DeleteTeacherCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
    }
}