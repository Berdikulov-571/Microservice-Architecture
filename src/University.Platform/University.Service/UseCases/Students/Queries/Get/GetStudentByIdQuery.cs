using MediatR;
using University.Domain.Entities.Students;

namespace University.Service.UseCases.Students.Queries.Get
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}