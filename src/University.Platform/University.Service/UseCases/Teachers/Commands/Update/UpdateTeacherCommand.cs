using MediatR;
using University.Domain.Dtos.Teachers;

namespace University.Service.UseCases.Teachers.Commands.Update
{
    public class UpdateTeacherCommand : TeacherUpdateDto, IRequest<int>
    {

    }
}