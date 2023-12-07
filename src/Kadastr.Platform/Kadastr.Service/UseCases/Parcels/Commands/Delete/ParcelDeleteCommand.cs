using MediatR;

namespace Kadastr.Service.UseCases.Parcels.Commands.Delete
{
    public class ParcelDeleteCommand : IRequest<int>
    {
        public int ParcelId { get; set; }
    }
}