using MediatR;
using PublicTransport.Domain.Entities.Routes;

namespace PublicTransport.Service.UseCases.Routes.Queries
{
    public class GetRouteByIdQuery : IRequest<Route>
    {
        public int RouteId { get; set; }
    }
}