using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Payments.Commands;

namespace PublicTransport.Service.UseCases.Payments.Handlers
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeletePaymentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == request.PaymentId, cancellationToken);

            if (payment == null)
            {
                return 0;
            }

            _context.Payments.Remove(payment);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}