using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.ClassTasks;
using School.Domain.Entities.Teachers;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.ClassTasks.Queries.Get;

namespace School.Service.UseCases.ClassTasks.Handlers.Get
{
    public class GetAllClassTaskCommandHandler : IRequestHandler<GetAllClassTasksQuery, IEnumerable<Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllClassTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllClassTasksQuery request, CancellationToken cancellationToken)
        {
            List<Teacher> classTasks = await _context.Teachers.Include(x => x.ClassTasks).ThenInclude(x => x.Task).ToListAsync(cancellationToken);
            List<School.Domain.Entities.Task.Tasks> classTasks2 = await _context.Tasks.Include(x => x.ClassTasks).ThenInclude(x => x.Teacher).ToListAsync(cancellationToken);

            return classTasks;
        }
    }
}