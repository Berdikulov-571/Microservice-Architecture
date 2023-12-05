using MediatR;
using School.Domain.Dtos.Students;

namespace School.Service.Abstractions.UseCases.Students.Commands.Update
{
    public class UpdateStudentCommand : StudentUpdateDto, IRequest<int>
    {
    }
}