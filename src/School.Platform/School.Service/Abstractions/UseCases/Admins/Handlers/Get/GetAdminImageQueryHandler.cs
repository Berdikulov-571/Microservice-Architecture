using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Exceptions.Admins;
using School.Domain.Exceptions.Image;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Admins.Queries.Get;
using School.Service.Interfaces.File;

namespace School.Service.Abstractions.UseCases.Admins.Handlers.Get
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
