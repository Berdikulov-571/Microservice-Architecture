using MediatR;
using University.Domain.Entities.Dedlines;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Dedlines.Commands.Create;

namespace University.Service.UseCases.Dedlines.Handlers.Create
{
    public class CreateDedlineCommandHandler : IRequestHandler<CreateDedlineCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateDedlineCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateDedlineCommand request, CancellationToken cancellationToken)
        {
            Dedline dedline = new Dedline()
            {
                CourseId = request.CourseId,
                FilePath = await _fileService.UploadFileAsync(request.FilePath),
                MaxGrade = request.MaxGrade,
                ExpiredDate = request.ExpiredDate,
                CreatedAt = DateTime.Now,
            };

            await _context.Dedlines.AddAsync(dedline, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}