using MediatR;
using University.Domain.Entities.Subjects;

namespace University.Service.UseCases.Subjects.Queries.Get
{
    public class GetSubjectByIdQuery : IRequest<Subject>
    {
        public int SubjectId { get; set; }
    }
}