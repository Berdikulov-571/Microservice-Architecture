using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Service.UseCases.Subjects.Queries.Get
{
    public class GetSubjectByIdQuery : IRequest<Subject>
    {
        public int SubjectId { get; set; }
    }
}