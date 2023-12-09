using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Payments.Queries;

namespace PublicTransport.Service.UseCases.Payments.Handlers
{
    public class GetAllPaymentQueryHandler : IRequestHandler<GetAllPaymentQuery, IEnumerable<Payment>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPaymentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            var payments = await _context.Payments.ToListAsync(cancellationToken);

            return payments;
        }
    }
}