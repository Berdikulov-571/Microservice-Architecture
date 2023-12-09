using MediatR;
using PublicTransport.Domain.Entities.Payments;

namespace PublicTransport.Service.UseCases.Payments.Queries
{
    public class GetAllPaymentQuery : IRequest<IEnumerable<Payment>>
    {

    }
}