using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Service.UseCases.TeacherSubjectRelation.Queries.Get
{
    public class GetAllTeacherSubjectQuery : IRequest<IEnumerable<Subject>>
    {

    }
}