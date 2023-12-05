using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Image;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.UseCases.Students.Commands.Delete;

namespace School.Service.UseCases.Students.Handlers.Delete
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteStudentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

            if (student == null)
                throw new StudentNotFound();

            try
            {
                await _fileService.DeleteImageAsync(student.ImagePath);
            }
            catch
            {
                throw new ImageNotFound();
            }

            _context.Students.Remove(student);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
