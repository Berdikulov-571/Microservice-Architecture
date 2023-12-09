using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Users.Commands;

namespace PublicTransport.Service.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            if (result == null)
            {
                return 0;
            }

            _context.Users.Remove(result);
            int res = await _context.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}