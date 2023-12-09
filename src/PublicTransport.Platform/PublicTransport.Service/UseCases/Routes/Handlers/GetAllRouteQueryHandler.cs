using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Routes.Queries;

namespace PublicTransport.Service.UseCases.Routes.Handlers
{
    public class GetAllRouteQueryHandler : IRequestHandler<GetAllRouteQuery, IEnumerable<Route>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRouteQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Route>> Handle(GetAllRouteQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Routes.ToListAsync(cancellationToken);

            return result;
        }
    }
}