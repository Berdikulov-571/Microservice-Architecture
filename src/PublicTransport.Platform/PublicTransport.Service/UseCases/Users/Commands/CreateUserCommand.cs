using MediatR;
using PublicTransport.Domain.Dtos.Users;

namespace PublicTransport.Service.UseCases.Users.Commands
{
    public class CreateUserCommand : UserCreateDto, IRequest<int>
    {

    }
}