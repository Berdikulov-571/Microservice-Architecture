using MediatR;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Payments.Commands;

namespace PublicTransport.Service.UseCases.Payments.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePaymentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = new Payment()
            {
                Amaunt = request.Amaunt,
                PaymentDate = DateTime.Now,
                TransportId = request.TransportId,
                UserId = request.UserId,
            };

            await _context.Payments.AddAsync(payment,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}