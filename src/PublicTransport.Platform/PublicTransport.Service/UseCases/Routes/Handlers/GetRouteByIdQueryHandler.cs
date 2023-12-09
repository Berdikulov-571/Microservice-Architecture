using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Routes.Queries;

namespace PublicTransport.Service.UseCases.Routes.Handlers
{
    public class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, Route>
    {
        private readonly IApplicationDbContext _context;

        public GetRouteByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Route> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(x => x.Id == request.RouteId, cancellationToken);

            return route;
        }
    }
}