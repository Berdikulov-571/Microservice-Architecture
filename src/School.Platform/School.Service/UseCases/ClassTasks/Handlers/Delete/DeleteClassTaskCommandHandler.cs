using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.ClassTasks;
using School.Domain.Exceptions.ClassTasks;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.ClassTasks.Commands.Delete;

namespace School.Service.UseCases.ClassTasks.Handlers.Delete
{
    public class DeleteClassTaskCommandHandler : IRequestHandler<DeleteClassTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteClassTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteClassTaskCommand request, CancellationToken cancellationToken)
        {
            ClassTask? classTask = await _context.ClassTasks.FirstOrDefaultAsync(x => x.ClassTaskId == request.ClassTaskId, cancellationToken);

            if (classTask == null)
                throw new ClassTaskNotFound();

            _context.ClassTasks.Remove(classTask);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}