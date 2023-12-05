using MediatR;

namespace School.Service.UseCases.Teachers.Queries.Get
{
    public class GetTeacherImageQuery : IRequest<byte[]>
    {
        public int TeacherId { get; set; }
    }
}