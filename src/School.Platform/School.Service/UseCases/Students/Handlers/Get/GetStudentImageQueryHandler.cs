using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Image;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.UseCases.Students.Queries.Get;

namespace School.Service.UseCases.Students.Handlers.Get
{
    public class GetStudentImageQueryHandler : IRequestHandler<GetStudentImageQuery, byte[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GetStudentImageQueryHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(GetStudentImageQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

            if (student == null)
                throw new StudentNotFound();
            else if (student.ImagePath == null)
                throw new ImageNotFound();

            byte[] image = await _fileService.GetImageAsync(student.ImagePath);

            return image;
        }
    }
}