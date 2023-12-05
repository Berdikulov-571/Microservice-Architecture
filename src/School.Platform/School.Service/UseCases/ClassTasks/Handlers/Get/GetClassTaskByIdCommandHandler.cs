using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.ClassTasks.Queries.Get;

namespace School.Service.UseCases.ClassTasks.Handlers.Get
{
    public class GetClassTaskByIdCommandHandler : IRequestHandler<GetClassTaskByIdQuery, List<Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetClassTaskByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetClassTaskByIdQuery request, CancellationToken cancellationToken)
        {
            List<Teacher> result = await _context.Teachers.Include(x => x.ClassTasks).ThenInclude(x => x.Task).Where(x => x.TeacherId == request.TeacherId).ToListAsync(cancellationToken);

            return result!;
        }
    }
}
