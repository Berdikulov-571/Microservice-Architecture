using MediatR;

namespace PublicTransport.Service.UseCases.Payments.Commands
{
    public class DeletePaymentCommand : IRequest<int>
    {
        public int PaymentId { get; set; }
    }
}