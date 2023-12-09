using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Users;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Users.Commands;

namespace PublicTransport.Service.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            user.UpdatedAt = DateTime.Now;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Password = request.Password;
            user.PhoneNumber = request.PhoneNumber;
            user.UserName = request.UserName;

            _context.Users.Update(user);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}