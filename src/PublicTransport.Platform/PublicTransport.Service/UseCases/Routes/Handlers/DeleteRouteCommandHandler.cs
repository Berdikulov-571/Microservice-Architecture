using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Routes.Commands;

namespace PublicTransport.Service.UseCases.Routes.Handlers
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRouteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            Route route = await _context.Routes.FirstOrDefaultAsync(x => x.Id == request.RouteId, cancellationToken);

            if (route == null)
            {
                return 0;
            }

            _context.Routes.Remove(route);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}