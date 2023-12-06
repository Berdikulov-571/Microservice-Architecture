using MediatR;
using University.Domain.Entities.Students;

namespace University.Service.UseCases.Students.Queries.Get
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {

    }
}