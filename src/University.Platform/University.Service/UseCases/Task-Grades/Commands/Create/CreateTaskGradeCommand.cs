using MediatR;
using University.Domain.Dtos.Task_Grades;

namespace University.Service.UseCases.Task_Grades.Commands.Create
{
    public class CreateTaskGradeCommand : TaskGradeCreateDto, IRequest<int>
    {
 
    }
}