using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Routes.Commands;

namespace PublicTransport.Service.UseCases.Routes.Handlers
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRouteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            Route route = await _context.Routes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            route.StartLocation = request.StartLocation;
            route.EndLocation = request.EndLocation;
            route.RouteName = request.RouteName;

            _context.Routes.Update(route);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}