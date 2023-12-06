using MediatR;
using University.Domain.Dtos.Students;

namespace University.Service.UseCases.Students.Commands.Create
{
    public class CreateStudentCommand : StudentCreateDto, IRequest<int>
    {

    }
}