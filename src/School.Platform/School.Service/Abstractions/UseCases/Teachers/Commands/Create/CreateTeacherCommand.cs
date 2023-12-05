using MediatR;
using School.Domain.Dtos.Teachers;

namespace School.Service.Abstractions.UseCases.Teachers.Commands.Create
{
    public class CreateTeacherCommand : TeacherCreateDto, IRequest<int>
    {

    }
}
