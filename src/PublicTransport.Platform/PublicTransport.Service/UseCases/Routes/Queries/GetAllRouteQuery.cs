using MediatR;
using PublicTransport.Domain.Entities.Routes;

namespace PublicTransport.Service.UseCases.Routes.Queries
{
    public class GetAllRouteQuery : IRequest<IEnumerable<Route>>
    {
    }
}