using MediatR;
using School.Domain.Dtos.TeacherSubjectRelation;

namespace School.Service.UseCases.TeacherSubjectRelation.Commands.Create
{
    public class CreateTeacherSubjectCommand : TeacherSubjectsCreateDto, IRequest<int>
    {

    }
}