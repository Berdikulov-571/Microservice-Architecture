using MediatR;

namespace School.Service.UseCases.TeacherSubjectRelation.Commands.Delete
{
    public class DeleteTeacherSubjectCommand : IRequest<int>
    {
        public int TeacherSubjectId { get; set; }
    }
}