using MediatR;

namespace University.Service.UseCases.Task_Grades.Commands.Delete
{
    public class DeleteTaskGradeCommand : IRequest<int>
    {
        public int TaskGradeId { get; set; }
    }
}