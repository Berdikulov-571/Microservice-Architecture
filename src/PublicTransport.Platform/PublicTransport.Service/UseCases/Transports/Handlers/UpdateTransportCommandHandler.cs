using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Commands;

namespace PublicTransport.Service.UseCases.Transports.Handlers
{
    public class UpdateTransportCommandHandler : IRequestHandler<UpdateTransportCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTransportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
        {
            var transport = await _context.Transports.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            transport.Capacity = request.Capacity;
            transport.TransportName = request.TransportName;
            transport.TransportType = request.TransportType;

            _context.Transports.Update(transport);
            int res = await _context.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}