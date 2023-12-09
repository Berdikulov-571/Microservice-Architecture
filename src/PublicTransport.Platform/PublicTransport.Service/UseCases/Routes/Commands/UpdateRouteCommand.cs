using MediatR;
using PublicTransport.Domain.Dtos.Routes;

namespace PublicTransport.Service.UseCases.Routes.Commands
{
    public class UpdateRouteCommand : RouteUpdateDto, IRequest<int>
    {
    }
}