using MediatR;
using PublicTransport.Domain.Dtos.Routes;

namespace PublicTransport.Service.UseCases.Routes.Commands
{
    public class CreateRouteCommand : RouteCreateDto, IRequest<int>
    {

    }
}