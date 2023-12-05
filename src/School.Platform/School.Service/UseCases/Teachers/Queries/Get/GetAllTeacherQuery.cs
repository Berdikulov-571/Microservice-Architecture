using MediatR;
using School.Domain.Entities.Teachers;

namespace School.Service.UseCases.Teachers.Queries.Get
{
    public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
    {

    }
}
