using MediatR;
using University.Domain.Entities.Subjects;

namespace University.Service.UseCases.Subjects.Queries.Get
{
    public class GetAllSubjectQuery : IRequest<IEnumerable<Subject>>
    {

    }
}