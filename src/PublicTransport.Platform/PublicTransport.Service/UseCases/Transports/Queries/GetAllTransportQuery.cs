using MediatR;
using PublicTransport.Domain.Entities.Transports;

namespace PublicTransport.Service.UseCases.Transports.Queries
{
    public class GetAllTransportQuery : IRequest<IEnumerable<Transport>>
    {
    }
}