using Kadastr.Domain.Entities.Transactions;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Transactions.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Transactions.Handlers.Get
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        private readonly IApplicationDbContext _context;

        public GetTransactionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.TransactionID == request.TransactionId, cancellationToken);

            return transaction;
        }
    }
}