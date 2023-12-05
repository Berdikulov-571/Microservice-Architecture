using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.ClassTasks;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.ClassTasks.Commands.Update;

namespace School.Service.UseCases.ClassTasks.Handlers.Update
{
    public class UpdateClassTaskCommandHandler : IRequestHandler<UpdateClassTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateClassTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateClassTaskCommand request, CancellationToken cancellationToken)
        {
            ClassTask? classTask = await _context.ClassTasks.FirstOrDefaultAsync(x => x.ClassTaskId == request.ClassTaskId);

            classTask.TeacherId = request.TeacherId;
            classTask.TaskId = request.TaskId;

            _context.ClassTasks.Update(classTask);
            int res = await _context.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}