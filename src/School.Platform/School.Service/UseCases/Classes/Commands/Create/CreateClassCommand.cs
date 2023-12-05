using MediatR;
using School.Domain.Dtos.Classes;

namespace School.Service.UseCases.Classes.Commands.Create
{
    public class CreateClassCommand : ClassCreateDto, IRequest<int>
    {

    }
}