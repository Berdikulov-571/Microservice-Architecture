using MediatR;
using PublicTransport.Domain.Entities.Users;

namespace PublicTransport.Service.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}