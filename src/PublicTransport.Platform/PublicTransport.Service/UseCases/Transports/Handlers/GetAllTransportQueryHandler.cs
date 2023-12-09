using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Queries;

namespace PublicTransport.Service.UseCases.Transports.Handlers
{
    public class GetAllTransportQueryHandler : IRequestHandler<GetAllTransportQuery, IEnumerable<Transport>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTransportQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transport>> Handle(GetAllTransportQuery request, CancellationToken cancellationToken)
        {
            var transports = await _context.Transports.ToListAsync(cancellationToken);

            return transports;
        }
    }
}