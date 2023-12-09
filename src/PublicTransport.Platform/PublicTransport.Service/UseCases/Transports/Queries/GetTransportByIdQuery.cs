using MediatR;
using PublicTransport.Domain.Entities.Transports;

namespace PublicTransport.Service.UseCases.Transports.Queries
{
    public class GetTransportByIdQuery : IRequest<Transport>
    {
        public int TransportId { get; set; }
    }
}