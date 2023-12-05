using MediatR;
using School.Domain.Dtos.Teachers;

namespace School.Service.UseCases.Teachers.Commands.Create
{
    public class CreateTeacherCommand : TeacherCreateDto, IRequest<int>
    {

    }
}
