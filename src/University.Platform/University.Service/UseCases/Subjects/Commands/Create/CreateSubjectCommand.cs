using MediatR;
using University.Domain.Dtos.Subjects;

namespace University.Service.UseCases.Subjects.Commands.Create
{
    public class CreateSubjectCommand : SubjectCreateDto, IRequest<int>
    {

    }
}