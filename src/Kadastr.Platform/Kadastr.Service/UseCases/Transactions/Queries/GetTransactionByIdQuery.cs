using Kadastr.Domain.Entities.Transactions;
using MediatR;

namespace Kadastr.Service.UseCases.Transactions.Queries
{
    public class GetTransactionByIdQuery : IRequest<Transaction>
    {
        public int TransactionId { get; set; }
    }
}