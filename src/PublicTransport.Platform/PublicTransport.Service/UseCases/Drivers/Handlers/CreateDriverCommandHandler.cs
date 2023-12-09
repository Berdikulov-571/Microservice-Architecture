using MediatR;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Drivers.Commands;

namespace PublicTransport.Service.UseCases.Drivers.Handlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDriverCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            Driver driver = new Driver()
            {
                DriveName = request.DriveName,
                LicenseNumber = request.LicenseNumber,
                TransportId = request.TransportId,
            };

            await _context.Drivers.AddAsync(driver, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}