using MediatR;
using University.Domain.Entities.Task_Grades;

namespace University.Service.UseCases.Task_Grades.Queries.Get
{
    public class GetAllTaskGradeQuery : IRequest<IEnumerable<TaskGrade>>
    {

    }
}