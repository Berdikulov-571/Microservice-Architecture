using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Image;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Teachers.Queries.Get;
using School.Service.Interfaces.File;

namespace School.Service.Abstractions.UseCases.Teachers.Handlers.Get
{
    public class GetTeaecherImageQueryHandler : IRequestHandler<GetTeacherImageQuery, byte[]>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _context;

        public GetTeaecherImageQueryHandler(IFileService fileService, IApplicationDbContext context)
        {
            _fileService = fileService;
            _context = context;
        }

        public async Task<byte[]> Handle(GetTeacherImageQuery request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId);

            if (teacher == null)
                throw new TeacherNotFound();
            else if (teacher.ImagePath == null)
                throw new ImageNotFound();

            byte[] image = await _fileService.GetImageAsync(teacher.ImagePath);

            return image;
        }
    }
}