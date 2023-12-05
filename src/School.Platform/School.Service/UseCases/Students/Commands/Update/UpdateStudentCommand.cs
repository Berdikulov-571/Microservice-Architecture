using MediatR;
using School.Domain.Dtos.Students;

namespace School.Service.UseCases.Students.Commands.Update
{
    public class UpdateStudentCommand : StudentUpdateDto, IRequest<int>
    {
    }
}