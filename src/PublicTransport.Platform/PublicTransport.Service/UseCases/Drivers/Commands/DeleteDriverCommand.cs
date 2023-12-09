using MediatR;

namespace PublicTransport.Service.UseCases.Drivers.Commands
{
    public class DeleteDriverCommand : IRequest<int>
    {
        public int DriverId { get; set; }
    }
}