using Kadastr.Domain.Entities.Transactions;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Transactions.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Transactions.Handlers.Get
{
    public class GetAllTransactionQueryHandler : IRequestHandler<GetAllTransactionQuery, IEnumerable<Transaction>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTransactionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _context.Transactions.ToListAsync(cancellationToken);

            return transactions;
        }
    }
}