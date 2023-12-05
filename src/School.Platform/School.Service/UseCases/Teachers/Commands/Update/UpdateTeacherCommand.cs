using MediatR;
using School.Domain.Dtos.Teachers;

namespace School.Service.UseCases.Teachers.Commands.Update
{
    public class UpdateTeacherCommand : TeacherUpdateDto, IRequest<int>
    {

    }
}
