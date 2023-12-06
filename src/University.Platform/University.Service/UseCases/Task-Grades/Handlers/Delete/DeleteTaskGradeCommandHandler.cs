using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Task_Grades;
using University.Domain.Exceptions.Task_Grade;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Task_Grades.Commands.Delete;

namespace University.Service.UseCases.Task_Grades.Handlers.Delete
{
    public class DeleteTaskGradeCommandHandler : IRequestHandler<DeleteTaskGradeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteTaskGradeCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        async Task<int> IRequestHandler<DeleteTaskGradeCommand, int>.Handle(DeleteTaskGradeCommand request, CancellationToken cancellationToken)
        {
            TaskGrade? taskGrade = await _context.TaskGrades.FirstOrDefaultAsync(x => x.TaskGradeId == request.TaskGradeId, cancellationToken);

            if (taskGrade == null)
                throw new TaskGradeNotFound();

            try
            {
                await _fileService.DeletFileAsync(taskGrade.FilePath);
            }
            catch
            {
                throw new FileNotFoundException();
            }

            _context.TaskGrades.Update(taskGrade);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}