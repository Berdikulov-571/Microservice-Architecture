using MediatR;
using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Commands;

namespace PublicTransport.Service.UseCases.Transports.Handlers
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommand, int>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateTransportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            Transport transport = new Transport()
            {
                Capacity = request.Capacity,
                TransportName = request.TransportName,
                TransportType = request.TransportType,
            };

            await _context.Transports.AddAsync(transport,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result + 1;
        }
    }
}