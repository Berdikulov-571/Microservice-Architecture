using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Task_Grades;
using University.Domain.Exceptions.Task_Grade;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Task_Grades.Queries.Get;

namespace University.Service.UseCases.Task_Grades.Handlers.Get
{
    public class GetTaskGradeByIdQueryHandler : IRequestHandler<GetTaskGradeByIdQuery, TaskGrade>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskGradeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskGrade> Handle(GetTaskGradeByIdQuery request, CancellationToken cancellationToken)
        {
            TaskGrade? taskGrade = await _context.TaskGrades.FirstOrDefaultAsync(x => x.TaskGradeId == request.TaskGradeId,cancellationToken);

            if (taskGrade == null)
                throw new TaskGradeNotFound();

            return taskGrade;
        }
    }
}