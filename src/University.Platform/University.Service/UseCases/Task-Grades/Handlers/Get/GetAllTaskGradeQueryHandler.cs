using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Task_Grades;
using University.Domain.Exceptions.Task_Grade;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Task_Grades.Queries.Get;

namespace University.Service.UseCases.Task_Grades.Handlers.Get
{
    public class GetAllTaskGradeQueryHandler : IRequestHandler<GetAllTaskGradeQuery, IEnumerable<TaskGrade>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTaskGradeQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskGrade>> Handle(GetAllTaskGradeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TaskGrade> taskGrades = await _context.TaskGrades.ToListAsync(cancellationToken);

            if (taskGrades == null)
                throw new TaskGradeNotFound();

            return taskGrades;
        }
    }
}