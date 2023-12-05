using MediatR;

namespace School.Service.UseCases.Students.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
    }
}
