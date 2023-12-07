using Kadastr.Domain.Entities.LegalDescriptions;
using MediatR;

namespace Kadastr.Service.UseCases.LegalDescriptions.Queries
{
    public class GetLegalDescriptionByIdQuery : IRequest<LegalDescription>
    {
        public int LegalDescriptionId { get; set; } 
    }
}