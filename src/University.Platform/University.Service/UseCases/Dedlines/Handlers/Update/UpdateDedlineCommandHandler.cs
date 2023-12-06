using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Dedlines;
using University.Domain.Exceptions.Dedlines;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.UseCases.Dedlines.Commands.Update;

namespace University.Service.UseCases.Dedlines.Handlers.Update
{
    public class UpdateDedlineCommandHandler : IRequestHandler<UpdateDedlineCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _filService;

        public UpdateDedlineCommandHandler(IApplicationDbContext context, IFileService filService)
        {
            _context = context;
            _filService = filService;
        }

        public async Task<int> Handle(UpdateDedlineCommand request, CancellationToken cancellationToken)
        {
            Dedline? dedline = await _context.Dedlines.FirstOrDefaultAsync(x => x.DedlineId == request.DedlineId, cancellationToken);

            if (dedline == null)
                throw new DedlineNotFound();

            dedline.CourseId = request.CourseId;
            dedline.MaxGrade = request.MaxGrade;
            dedline.ExpiredDate = request.ExpiredDate;
            dedline.UpdateAt = DateTime.Now;

            if (request.FilePath != null)
            {
                await _filService.DeletFileAsync(dedline.FilePath);
                dedline.FilePath = await _filService.UploadFileAsync(request.FilePath);
            }

            _context.Dedlines.Update(dedline);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}