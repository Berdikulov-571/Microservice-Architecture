using MediatR;

namespace University.Service.UseCases.Students.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
    }
}