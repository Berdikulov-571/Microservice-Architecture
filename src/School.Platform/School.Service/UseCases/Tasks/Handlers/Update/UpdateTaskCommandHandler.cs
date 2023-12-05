using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Exceptions.Task;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Tasks.Commands.Update;

namespace School.Service.UseCases.Tasks.Handlers.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Task.Tasks? task = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

            if (task == null)
                throw new TaskNotFound();

            task.Description = request.Description;
            task.UpdatedAt = DateTime.Now;

            _context.Tasks.Update(task);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}