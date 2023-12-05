using MediatR;
using School.Domain.Entities.Students;

namespace School.Service.Abstractions.UseCases.Students.Queries.Get
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}