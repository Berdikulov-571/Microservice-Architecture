using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Exceptions.Task;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Tasks.Commands.Delete;

namespace School.Service.Abstractions.UseCases.Tasks.Handlers.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            School.Domain.Entities.Task.Tasks? task = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == request.TaskId,cancellationToken);

            if (task == null)
                throw new TaskNotFound();

            _context.Tasks.Remove(task);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}