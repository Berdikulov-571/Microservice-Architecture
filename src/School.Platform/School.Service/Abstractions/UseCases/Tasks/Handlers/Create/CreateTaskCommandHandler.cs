using MediatR;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Tasks.Commands.Create;

namespace School.Service.Abstractions.UseCases.Tasks.Handlers.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            School.Domain.Entities.Task.Tasks task = new School.Domain.Entities.Task.Tasks()
            {
                Description = request.Description,
                CreatedAt = DateTime.Now,
            };

            await _context.Tasks.AddAsync(task,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}