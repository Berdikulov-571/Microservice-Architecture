using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Exceptions.Admins;
using University.Domain.Exceptions.Files;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Admins.Commands.Delete;

namespace University.Service.UseCases.Admins.Handlers.Delete
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand,int>
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