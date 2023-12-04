using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Exceptions.Admins;
using School.Domain.Exceptions.Image;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Admins.Commands.Delete;
using School.Service.Interfaces.File;

namespace School.Service.Abstractions.UseCases.Admins.Handlers.Delete
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteAdminCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
            {
                throw new AdminNotFound();
            }

            try
            {
                await _fileService.DeleteImageAsync(admin.ImagePath);
            }
            catch
            {
                throw new ImageNotFound();
            }
            _context.Admins.Remove(admin);

            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}

