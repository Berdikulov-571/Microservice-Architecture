using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Entities.Admins;
using School.Domain.Enums.RoleEnum;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Admins.Commands.Create;
using School.Service.Interfaces.File;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Admins.Handlers.Create
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDistributedCache _cache;

        public CreateAdminCommandHandler(IApplicationDbContext context, IFileService fileService, IDistributedCache cache)
        {
            _context = context;
            _fileService = fileService;
            _cache = cache;
        }

        public async Task<int> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? checkUserName = await _context.Admins.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
            Admin? checkEmail = await _context.Admins.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkUserName != null)
            {
                throw new UserNameAlreadyExistsException();
            }
            else if(checkEmail != null)
            {
                throw new EmailAlreadyExistsException();
            }

            string imagePath = await _fileService.UploadImageAsync(request.ImagePath);

            Admin admin = new Admin()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = imagePath,
                Email = request.Email,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password),
                Role = Role.Admin
            };

            await _context.Admins.AddAsync(admin, cancellationToken);

            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
