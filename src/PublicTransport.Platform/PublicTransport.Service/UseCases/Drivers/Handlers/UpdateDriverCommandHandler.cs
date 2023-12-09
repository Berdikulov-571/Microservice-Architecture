using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Drivers.Commands;

namespace PublicTransport.Service.UseCases.Drivers.Handlers
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDriverCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            Driver driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (driver == null)
            {
                return 0;
            }

            driver.DriveName = request.DriveName;
            driver.TransportId = request.TransportId;
            driver.LicenseNumber = request.LicenseNumber;

            _context.Drivers.Update(driver);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}