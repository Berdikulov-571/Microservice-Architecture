using MediatR;

namespace University.Service.UseCases.Subjects.Commands.Delete
{
    public class DeleteSubjectCommand : IRequest<int>
    {
        public int SubjectId { get;set; }
    }
}