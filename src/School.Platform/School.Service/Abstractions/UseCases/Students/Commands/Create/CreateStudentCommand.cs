using MediatR;
using School.Domain.Dtos.Students;

namespace School.Service.Abstractions.UseCases.Students.Commands.Create
{
    public class CreateStudentCommand : StudentCreateDto, IRequest<int>
    {
    }
}