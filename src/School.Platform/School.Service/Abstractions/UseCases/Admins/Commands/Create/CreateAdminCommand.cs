using MediatR;
using School.Domain.Dtos.Admins;

namespace School.Service.Abstractions.UseCases.Admins.Commands.Create
{
    public class CreateAdminCommand : AdminCreateDto, IRequest<int>
    {

    }
}