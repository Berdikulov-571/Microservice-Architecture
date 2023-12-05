using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Service.UseCases.TeacherSubjectRelation.Queries.Get
{
    public class GetTeacherSubjectByTeacherIdQuery : IRequest<IEnumerable<Subject>>
    {
        public int TeacherId { get; set; }
    }
}