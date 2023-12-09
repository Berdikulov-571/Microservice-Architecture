using MediatR;
using PublicTransport.Domain.Entities.Users;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Users.Commands;

namespace PublicTransport.Service.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                CreatedAt = DateTime.UtcNow,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                Role = Domain.Enums.Roles.Role.User,
            };

            await _context.Users.AddAsync(user);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}