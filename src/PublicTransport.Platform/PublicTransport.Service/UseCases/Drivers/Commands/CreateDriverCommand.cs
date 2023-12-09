using MediatR;
using PublicTransport.Domain.Dtos.Drivers;

namespace PublicTransport.Service.UseCases.Drivers.Commands
{
    public class CreateDriverCommand : DriverCreateDto, IRequest<int>
    {

    }
}