using MediatR;
using PublicTransport.Domain.Dtos.Drivers;

namespace PublicTransport.Service.UseCases.Drivers.Commands
{
    public class UpdateDriverCommand : DriverUpdateDto, IRequest<int>
    {

    }
}