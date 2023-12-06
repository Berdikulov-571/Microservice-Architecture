using MediatR;
using University.Domain.Entities.Groups;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Groups.Commands.Create;

namespace University.Service.UseCases.Groups.Handlers.Create
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = new Group()
            {
                Level = request.Level,
                Name = request.Name,
                CreatedAt = DateTime.Now,
            };

            await _context.Groups.AddAsync(group, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
