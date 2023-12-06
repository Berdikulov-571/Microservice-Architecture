using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Dedlines;
using University.Domain.Exceptions.Dedlines;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Dedlines.Commands.Delete;

namespace University.Service.UseCases.Dedlines.Handlers.Delete
{
    public class DeleteDedlineCommandHandler : IRequestHandler<DeleteDedlineCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteDedlineCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteDedlineCommand request, CancellationToken cancellationToken)
        {
            Dedline? dedline = await _context.Dedlines.FirstOrDefaultAsync(x => x.DedlineId == request.DedlineId, cancellationToken);

            if (dedline == null)
                throw new DedlineNotFound();

            await _fileService.DeletFileAsync(dedline.FilePath);

            _context.Dedlines.Remove(dedline);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}