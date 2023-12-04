using MediatR;
using School.Domain.Entities.Teachers;

namespace School.Service.Abstractions.UseCases.Teachers.Queries.Get
{
    public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
    {

    }
}
