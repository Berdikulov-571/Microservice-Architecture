using MediatR;
using School.Domain.Dtos.Subjects;

namespace School.Service.UseCases.Subjects.Commands.Create
{
    public class CreateSubjectCommand : SubjectCreateDto, IRequest<int>
    {

    }
}