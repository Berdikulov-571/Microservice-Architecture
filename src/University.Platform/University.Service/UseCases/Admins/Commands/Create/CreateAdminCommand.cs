using MediatR;
using University.Domain.Dtos.Admins;

namespace University.Service.UseCases.Admins.Commands.Create
{
    public class CreateAdminCommand : AdminCreateDto, IRequest<int>
    {

    }
}