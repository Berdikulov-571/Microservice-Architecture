using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Serilog;
using TelegramSink;
using University.Domain.Entities.Admins;
using University.Domain.Enums.Roles;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.UserName;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Admins.Commands.Create;

namespace University.Service.UseCases.Admins.Handlers.Create
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
                throw new UserNameAlreadyExists();
            }
            else if (checkEmail != null)
            {
                throw new EmailAlreadyExists();
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
                Role = Role.Admin,
                CreatedAt = DateTime.Now
            };


            await _context.Admins.AddAsync(admin, cancellationToken);

            int result = await _context.SaveChangesAsync(cancellationToken);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.TeleSink("6664729300:AAExS7StUJ7Q3BuaEFKF21pg5oWttBpD2-E", "2017110018")
                .CreateLogger();
           
            return result;
        }
    }
}