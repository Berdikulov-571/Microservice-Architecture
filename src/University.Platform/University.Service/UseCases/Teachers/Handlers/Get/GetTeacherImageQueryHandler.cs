using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Exceptions.Files;
using University.Domain.Exceptions.Teachers;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Teachers.Queries.Get;

namespace University.Service.UseCases.Teachers.Handlers.Get
{
    public class GetTeacherImageQueryHandler : IRequestHandler<GetTeacherImage, byte[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GetTeacherImageQueryHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(GetTeacherImage request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId, cancellationToken);

            if (teacher == null)
                throw new TeacherNotFound();
            else if (teacher.ImagePath == null)
                throw new ImageNotFound();

            byte[] image = await _fileService.GetImageAsync(teacher.ImagePath);

            return image;
        }
    }
}