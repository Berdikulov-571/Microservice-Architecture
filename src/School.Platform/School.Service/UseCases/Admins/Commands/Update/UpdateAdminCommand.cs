using MediatR;
using School.Domain.Dtos.Admins;

namespace School.Service.UseCases.Admins.Commands.Update
{
    public class UpdateAdminCommand : AdminUpdateDto, IRequest<int>
    {

    }
}