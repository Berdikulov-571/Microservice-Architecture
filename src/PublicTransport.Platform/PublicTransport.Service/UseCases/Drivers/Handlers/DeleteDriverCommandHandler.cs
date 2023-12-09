using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Drivers;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Drivers.Commands;

namespace PublicTransport.Service.UseCases.Drivers.Handlers
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDriverCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            Driver driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == request.DriverId, cancellationToken);

            if (driver == null)
            {
                return 0;
            }
            _context.Drivers.Remove(driver);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}