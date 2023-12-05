using MediatR;
using School.Domain.Entities.ClassTasks;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Classes.Commands.Create;
using School.Service.UseCases.ClassTasks.Commands.Create;

namespace School.Service.UseCases.ClassTasks.Handlers.Create
{
    public class CreateClassTaskCommandHandler : IRequestHandler<CreateClassTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateClassTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClassTaskCommand request, CancellationToken cancellationToken)
        {
            ClassTask clasTask = new ClassTask()
            {
                TaskId = request.TaskId,
                TeacherId = request.TeacherId,
            };

            await _context.ClassTasks.AddAsync(clasTask,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}