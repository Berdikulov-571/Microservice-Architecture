using MediatR;
using School.Domain.Dtos.Teachers;
using School.Service.Abstractions.DataAccess;

namespace School.Service.Abstractions.UseCases.Teachers.Commands.Create
{
    public class CreateTeacherCommand : TeacherCreateDto, IRequest<int>
    {

    }
}