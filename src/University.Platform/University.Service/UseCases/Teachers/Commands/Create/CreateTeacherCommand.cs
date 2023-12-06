using MediatR;
using University.Domain.Dtos.Teachers;

namespace University.Service.UseCases.Teachers.Commands.Create
{
    public class CreateTeacherCommand : TeacherCreateDto, IRequest<int>
    {

    }
}