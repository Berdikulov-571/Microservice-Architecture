using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Groups;
using University.Domain.Exceptions.Groups;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Groups.Commands.Delete;

namespace University.Service.UseCases.Groups.Handlers.Delete
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            Group? group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == request.GroupId,cancellationToken);

            if (group == null)
                throw new GroupNotFound();

            _context.Groups.Remove(group);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}