using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Queries;

namespace PublicTransport.Service.UseCases.Transports.Handlers
{
    public class GetTransportByIdQueryHandler : IRequestHandler<GetTransportByIdQuery, Transport>
    {
        private readonly IApplicationDbContext _context;

        public GetTransportByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transport> Handle(GetTransportByIdQuery request, CancellationToken cancellationToken)
        {
            var transport = await _context.Transports.FirstOrDefaultAsync(x => x.Id == request.TransportId, cancellationToken);

            return transport;
        }
    }
}