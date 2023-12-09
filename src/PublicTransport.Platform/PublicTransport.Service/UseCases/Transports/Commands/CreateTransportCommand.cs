using MediatR;
using PublicTransport.Domain.Dtos.Transports;

namespace PublicTransport.Service.UseCases.Transports.Commands
{
    public class CreateTransportCommand : TransportCreateDto, IRequest<int>
    {

    }
}