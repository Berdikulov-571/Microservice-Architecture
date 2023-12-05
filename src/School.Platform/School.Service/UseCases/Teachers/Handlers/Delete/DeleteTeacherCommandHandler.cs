using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Image;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.UseCases.Teachers.Commands.Delete;

namespace School.Service.UseCases.Teachers.Handlers.Delete
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteTeacherCommandHandler(IApplicationDbContext context, IFileService formFile)
        {
            _context = context;
            _fileService = formFile;
        }

        public async Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId, cancellationToken);

            if (teacher == null)
            {
                throw new TeacherNotFound();
            }

            try
            {
                await _fileService.DeleteImageAsync(teacher.ImagePath);
            }
            catch
            {
                throw new ImageNotFound();
            }

            _context.Teachers.Remove(teacher);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
