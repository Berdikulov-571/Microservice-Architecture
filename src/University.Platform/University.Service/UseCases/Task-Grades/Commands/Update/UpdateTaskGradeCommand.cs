using MediatR;
using University.Domain.Dtos.Task_Grades;

namespace University.Service.UseCases.Task_Grades.Commands.Update
{
    public class UpdateTaskGradeCommand : TaskGradeUpdateDto, IRequest<int>
    {

    }
}