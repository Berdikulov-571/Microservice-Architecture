using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Files;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Students.Commands.Delete;

namespace University.Service.UseCases.Students.Handlers.Delete
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