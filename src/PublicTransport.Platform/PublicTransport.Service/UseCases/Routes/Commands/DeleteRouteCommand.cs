using MediatR;

namespace PublicTransport.Service.UseCases.Routes.Commands
{
    public class DeleteRouteCommand : IRequest<int>
    {
        public int RouteId { get; set; }
    }
}