using MediatR;

namespace School.Service.UseCases.Subjects.Commands.Delete
{
    public class DeleteSubjectCommand : IRequest<int>
    {
        public int SubjectId { get; set; }
    }
}