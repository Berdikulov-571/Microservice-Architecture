using MediatR;

namespace Kadastr.Service.UseCases.LegalDescriptions.Commands.Delete
{
    public class DeleteLegalDescriptionCommand : IRequest<int>
    {
        public int LegalDescriptionId { get; set; }
    }
}