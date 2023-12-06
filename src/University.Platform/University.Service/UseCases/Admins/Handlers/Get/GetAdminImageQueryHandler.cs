using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Exceptions.Admins;
using University.Domain.Exceptions.Files;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Admins.Queries.Get;

namespace University.Service.UseCases.Admins.Handlers.Get
{
    public class GetAdminImageQueryHandler : IRequestHandler<GetAdminImageQuery, byte[]>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _context;

        public GetAdminImageQueryHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(GetAdminImageQuery request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId);

            if (admin == null)
                throw new AdminNotFound();
            else if (admin.ImagePath == null)
                throw new ImageNotFound();

            byte[] image = await _fileService.GetImageAsync(admin.ImagePath);

            return image;
        }
    }
}