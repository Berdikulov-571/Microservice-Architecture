using MediatR;
using University.Domain.Dtos.Admins;

namespace University.Service.UseCases.Admins.Commands.Update
{
    public class UpdateAdminCommand : AdminUpdateDto, IRequest<int>
    {

    }
}