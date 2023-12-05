using MediatR;
using School.Domain.Entities.Subjects;

namespace School.Service.UseCases.Subjects.Queries.Get
{
    public class GetAllSubjecttQuery : IRequest<IEnumerable<Subject>>
    {

    }
}