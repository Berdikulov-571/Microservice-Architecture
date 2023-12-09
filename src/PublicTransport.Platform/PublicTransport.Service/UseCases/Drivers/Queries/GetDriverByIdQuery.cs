using MediatR;
using PublicTransport.Domain.Entities.Drivers;

namespace PublicTransport.Service.UseCases.Drivers.Queries
{
    public class GetDriverByIdQuery : IRequest<Driver>
    {
        public int DriverId { get; set; }
    }
}