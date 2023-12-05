using MediatR;
using School.Domain.Dtos.Subjects;

namespace School.Service.UseCases.Subjects.Commands.Update
{
    public class UpdateSubjectCommand : SubjectUpdateDto, IRequest<int>
    {
    }
}