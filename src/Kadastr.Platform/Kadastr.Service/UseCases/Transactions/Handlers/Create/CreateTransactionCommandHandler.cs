using Kadastr.Domain.Entities.Transactions;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Transactions.Commands.Create;
using MediatR;

namespace Kadastr.Service.UseCases.Transactions.Handlers.Create
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTransactionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction transaction = new Transaction()
            {
                Amount = request.Amount,
                ParcelID = request.ParcelID,
                TransactionType = request.TransactionType,
                TransactionDate = DateTime.Now,
            };

            await _context.Transactions.AddAsync(transaction);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}