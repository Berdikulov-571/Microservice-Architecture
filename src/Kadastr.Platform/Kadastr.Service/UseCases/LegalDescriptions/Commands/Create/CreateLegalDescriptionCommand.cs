using Kadastr.Domain.Dtos.LegalDescriptions;
using MediatR;

namespace Kadastr.Service.UseCases.LegalDescriptions.Commands.Create
{
    public class CreateLegalDescriptionCommand : LegalDescriptionCreateDto, IRequest<int>
    {

    }
}