using MediatR;
using PublicTransport.Domain.Entities.Drivers;

namespace PublicTransport.Service.UseCases.Drivers.Queries
{
    public class GetAllDriverQuery : IRequest<IEnumerable<Driver>>
    {
    }
}