using Kadastr.Domain.Exceptions.Owners;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Owners.Handlers.Delete
{
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, int>
    {
        private IApplicationDbContext _context;

        public DeleteOwnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.OwnerID == request.OwnerId, cancellationToken);

            if (owner == null)
                throw new OwnerNotFound();

            _context.Owners.Remove(owner);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}