using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Drivers.Queries;

namespace PublicTransport.Service.UseCases.Drivers.Handlers
{
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, Driver>
    {
        private readonly IApplicationDbContext _context;

        public GetDriverByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            Driver driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == request.DriverId, cancellationToken);

            return driver;
        }
    }
}