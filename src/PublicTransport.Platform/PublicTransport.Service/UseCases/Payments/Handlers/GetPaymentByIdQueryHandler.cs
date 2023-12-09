using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Payments.Queries;

namespace PublicTransport.Service.UseCases.Payments.Handlers
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly IApplicationDbContext _context;

        public GetPaymentByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Payments.FirstOrDefaultAsync(x => x.Id == request.PaymentId, cancellationToken);

            return res;
        }
    }
}