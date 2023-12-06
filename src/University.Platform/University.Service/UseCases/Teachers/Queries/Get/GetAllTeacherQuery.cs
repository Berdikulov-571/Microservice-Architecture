using MediatR;
using University.Domain.Entities.Teachers;

namespace University.Service.UseCases.Teachers.Queries.Get
{
    public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
    {

    }
}