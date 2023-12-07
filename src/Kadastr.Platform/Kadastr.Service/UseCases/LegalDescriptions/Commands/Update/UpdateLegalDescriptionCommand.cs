using Kadastr.Domain.Dtos.LegalDescriptions;
using MediatR;

namespace Kadastr.Service.UseCases.LegalDescriptions.Commands.Update
{
    public class UpdateLegalDescriptionCommand : LegalDescriptionUpdateDto, IRequest<int>
    {

    }
}