using MediatR;
using PublicTransport.Domain.Entities.Users;

namespace PublicTransport.Service.UseCases.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}