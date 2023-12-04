using MediatR;
using School.Domain.Dtos.Admins;

namespace School.Service.Abstractions.UseCases.Admins.Commands.Update
{
    public class UpdateAdminCommand : AdminUpdateDto, IRequest<int>
    {

    }
}
