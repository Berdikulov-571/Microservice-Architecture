using MediatR;
using PublicTransport.Domain.Entities.Payments;

namespace PublicTransport.Service.UseCases.Payments.Queries
{
    public class GetPaymentByIdQuery : IRequest<Payment>
    {
        public int PaymentId { get; set; }
    }
}