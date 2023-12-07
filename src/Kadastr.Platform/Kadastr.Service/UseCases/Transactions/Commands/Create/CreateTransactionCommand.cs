using Kadastr.Domain.Dtos.Transactions;
using MediatR;

namespace Kadastr.Service.UseCases.Transactions.Commands.Create
{
    public class CreateTransactionCommand : TransactionCreateDto, IRequest<int>
    {
    }
}