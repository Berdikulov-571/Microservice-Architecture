using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Enums.RoleEnum;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Admins.Commands.Create;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Admins.Handlers.Create
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? checkUserName = await _context.Admins.FirstOrDefaultAsync(x => x.UserName == request.UserName);
            Admin? checkPhoneNumber = await _context.Admins.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (checkUserName != null)
            {
                throw new UserNameAlreadyExistsException();
            }
            else if (checkPhoneNumber != null)
            {
                throw new PhoneNumberAlreadyExistsException();
            }

            Admin admin = new Admin()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = Role.Admin,
                Email = request.Email,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password),
            };

            await _context.Admins.AddAsync(admin, cancellationToken);
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
