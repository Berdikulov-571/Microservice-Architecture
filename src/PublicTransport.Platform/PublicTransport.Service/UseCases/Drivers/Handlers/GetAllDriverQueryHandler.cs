using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Drivers.Queries;

namespace PublicTransport.Service.UseCases.Drivers.Handlers
{
    public class GetAllDriverQueryHandler : IRequestHandler<GetAllDriverQuery, IEnumerable<Driver>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDriverQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Driver>> Handle(GetAllDriverQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _context.Drivers.ToListAsync(cancellationToken);

            return drivers;
        }
    }
}