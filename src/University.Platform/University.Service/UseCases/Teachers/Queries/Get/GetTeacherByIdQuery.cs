using MediatR;
using University.Domain.Entities.Teachers;

namespace University.Service.UseCases.Teachers.Queries.Get
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public int TeacherId { get; set; }
    }
}