using MediatR;
using University.Domain.Dtos.Students;

namespace University.Service.UseCases.Students.Commands.Update
{
    public class UpdateStudentCommand : StudentUpdateDto, IRequest<int>
    {

    }
}