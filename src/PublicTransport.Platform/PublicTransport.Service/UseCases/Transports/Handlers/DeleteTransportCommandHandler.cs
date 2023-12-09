using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Commands;

namespace PublicTransport.Service.UseCases.Transports.Handlers
{
    public class DeleteTransportCommandHandler : IRequestHandler<DeleteTransportCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTransportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Transports.FirstOrDefaultAsync(x => x.Id == request.TransportId, cancellationToken);

            if (result == null)
            {
                return 0;
            }

            _context.Transports.Remove(result);
            int res = await _context.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}