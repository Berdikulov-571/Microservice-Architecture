using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Users;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Users.Queries;

namespace PublicTransport.Service.UseCases.Users.Handlers
{
    public class GetAllQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync(cancellationToken);

            return users;
        }
    }
}