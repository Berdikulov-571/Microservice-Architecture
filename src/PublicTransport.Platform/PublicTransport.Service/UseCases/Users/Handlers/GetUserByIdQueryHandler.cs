using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Users;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Users.Queries;

namespace PublicTransport.Service.UseCases.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            return user;
        }
    }
}