using MediatR;
using PublicTransport.Domain.Dtos.Payments;

namespace PublicTransport.Service.UseCases.Payments.Commands
{
    public class CreatePaymentCommand : PaymentCreateDto, IRequest<int>
    {

    }
}