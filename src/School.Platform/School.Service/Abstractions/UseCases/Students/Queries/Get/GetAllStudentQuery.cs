using MediatR;
using School.Domain.Entities.Students;

namespace School.Service.Abstractions.UseCases.Students.Queries.Get
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {

    }
}