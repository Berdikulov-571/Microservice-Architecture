using MediatR;
using University.Domain.Dtos.MissedLessons;

namespace University.Service.UseCases.MissedLessons.Commands.Update
{
    public class UpdateNbCommand : NbUpdateDto, IRequest<int>
    {

    }
}