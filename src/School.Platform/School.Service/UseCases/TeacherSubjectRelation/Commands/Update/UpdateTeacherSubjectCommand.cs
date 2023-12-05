using MediatR;
using School.Domain.Dtos.TeacherSubjectRelation;

namespace School.Service.UseCases.TeacherSubjectRelation.Commands.Update
{
    public class UpdateTeacherSubjectCommand : TeacherSubjectUpdateDto, IRequest<int>
    {

    }
}