using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Files;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Students.Queries.Get;

namespace University.Service.UseCases.Students.Handlers.Get
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