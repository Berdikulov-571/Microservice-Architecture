using MediatR;
using School.Domain.Dtos.Students;

namespace School.Service.UseCases.Students.Commands.Create
{
    public class CreateStudentCommand : StudentCreateDto, IRequest<int>
    {
    }
}