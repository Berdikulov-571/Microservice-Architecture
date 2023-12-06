using MediatR;

namespace University.Service.UseCases.Teachers.Queries.Get
{
    public class GetTeacherImage : IRequest<byte[]>
    {
        public int TeacherId { get; set; }
    }
}