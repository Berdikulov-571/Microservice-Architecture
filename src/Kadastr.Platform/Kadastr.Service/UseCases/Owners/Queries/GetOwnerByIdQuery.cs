using Kadastr.Domain.Entities.Owners;
using MediatR;

namespace Kadastr.Service.UseCases.Owners.Queries
{
    public class GetOwnerByIdQuery : IRequest<Owner>
    {
        public int OwnerId { get; set; }
    }
}