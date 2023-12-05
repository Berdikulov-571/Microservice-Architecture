using MediatR;
using School.Domain.Dtos.Classes;

namespace School.Service.UseCases.Classes.Commands.Update
{
    public class UpdateClassCommand : ClassUpdateDto, IRequest<int>
    {

    }
}