using Kadastr.Domain.Entities.Transactions;
using MediatR;

namespace Kadastr.Service.UseCases.Transactions.Queries
{
    public class GetAllTransactionQuery : IRequest<IEnumerable<Transaction>>
    {

    }
}