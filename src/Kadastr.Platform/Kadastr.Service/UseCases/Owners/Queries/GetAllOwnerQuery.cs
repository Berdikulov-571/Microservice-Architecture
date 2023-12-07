using Kadastr.Domain.Entities.Owners;
using MediatR;

namespace Kadastr.Service.UseCases.Owners.Queries
{
    public class GetAllOwnerQuery : IRequest<IEnumerable<Owner>>
    {

    }
}