using MediatR;
using University.Domain.Dtos.Subjects;

namespace University.Service.UseCases.Subjects.Commands.Update
{
    public class UpdateSubjectCommand : SubjectUpdateDto, IRequest<int>
    {

    }
}