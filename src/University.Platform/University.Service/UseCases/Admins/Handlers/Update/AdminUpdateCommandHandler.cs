using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Exceptions.Admins;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.UserName;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Admins.Commands.Update;

namespace University.Service.UseCases.Admins.Handlers.Update
{
    public class AdminUpdateCommandHandler : IRequestHandler<UpdateAdminCommand, int>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _context;

        public AdminUpdateCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
            {
                throw new AdminNotFound();
            }

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

            admin.UserName = request.UserName;
            admin.Email = request.Email;
            admin.FirstName = request.FirstName;
            admin.LastName = request.LastName;
            admin.UpdateAt = DateTime.Now;
            admin.PasswordHash = Hash512.ComputeSHA512HashFromString(request.Passwor);

            if (request.ImagePath != null)
            {
                await _fileService.DeleteImageAsync(admin.ImagePath);
                admin.ImagePath = await _fileService.UploadImageAsync(request.ImagePath);
            }

            _context.Admins.Update(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}