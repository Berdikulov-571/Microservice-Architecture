using MediatR;

namespace University.Service.UseCases.Students.Queries.Get
{
    public class GetStudentImageQuery : IRequest<byte[]>
    {
        public int StudentId { get; set; }
    }
}