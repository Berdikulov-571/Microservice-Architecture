using MediatR;
using School.Domain.Entities.Teachers;

namespace School.Service.Abstractions.UseCases.Teachers.Queries.Get
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public int TeacherId { get; set; }
    }
}
