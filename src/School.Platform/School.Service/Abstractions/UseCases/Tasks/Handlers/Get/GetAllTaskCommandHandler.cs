using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Exceptions.Task;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Tasks.Queries.Get;

namespace School.Service.Abstractions.UseCases.Tasks.Handlers.Get
{
    public class GetAllTaskCommandHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<School.Domain.Entities.Task.Tasks>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Task.Tasks>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<School.Domain.Entities.Task.Tasks>? tasks = await _context.Tasks.ToListAsync(cancellationToken);

            if (tasks == null)
                throw new TaskNotFound();

            return tasks;
        }
    }
}