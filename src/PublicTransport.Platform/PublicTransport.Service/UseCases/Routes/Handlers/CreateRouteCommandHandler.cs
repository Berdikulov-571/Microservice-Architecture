using MediatR;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Routes.Commands;

namespace PublicTransport.Service.UseCases.Routes.Handlers
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRouteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            Route route = new Route()
            {
                RouteName = request.RouteName,
                EndLocation = request.EndLocation,
                StartLocation = request.StartLocation,
            };

            await _context.Routes.AddAsync(route);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}