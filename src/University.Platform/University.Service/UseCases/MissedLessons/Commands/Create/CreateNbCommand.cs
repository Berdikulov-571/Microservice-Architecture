using MediatR;
using University.Domain.Dtos.MissedLessons;

namespace University.Service.UseCases.MissedLessons.Commands.Create
{
    public class CreateNbCommand : NbCreateDto, IRequest<int>
    {

    }
}