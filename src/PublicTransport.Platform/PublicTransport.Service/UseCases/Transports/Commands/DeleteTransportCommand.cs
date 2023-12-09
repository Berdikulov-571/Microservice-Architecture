using MediatR;

namespace PublicTransport.Service.UseCases.Transports.Commands
{
    public class DeleteTransportCommand : IRequest<int>
    {
        public int TransportId { get; set; }
    }
}