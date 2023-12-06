using MediatR;
using University.Domain.Entities.Task_Grades;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Task_Grades.Commands.Create;

namespace University.Service.UseCases.Task_Grades.Handlers.Create
{
    public class CreateTaskGradeCommandHandler : IRequestHandler<CreateTaskGradeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateTaskGradeCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateTaskGradeCommand request, CancellationToken cancellationToken)
        {
            string filePath = await _fileService.UploadFileAsync(request.File);

            TaskGrade taskGrade = new TaskGrade()
            {
                GradeValue = request.GradeValue,
                DedlineId = request.DedlineId,
                StudentId = request.StudentId,
                FilePath = filePath,
                IsUploaded = request.IsUploaded,
                IsRated = request.IsRated,
                CreatedAt = DateTime.Now,
            };

            await _context.TaskGrades.AddAsync(taskGrade, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}