using MediatR;

namespace School.Service.Abstractions.UseCases.Students.Queries.Get
{
    public class GetStudentImageQuery : IRequest<byte[]>
    {
        public int StudentId { get; set; }
    }
}