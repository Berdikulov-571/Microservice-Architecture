using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using University.Domain.Entities.Images;
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
        private readonly IDistributedCache _distributedCache;


        public DeleteStudentCommandHandler(IApplicationDbContext context, IFileService fileService, IDistributedCache distributedCache)
        {
            _context = context;
            _fileService = fileService;
            _distributedCache = distributedCache;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

            if (student == null)
                throw new StudentNotFound();

            string? cache = _distributedCache.GetString("UniversityStudent");

            if (cache != null)
            {
                var res = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);
                var response = res.FirstOrDefault(x => x.Id == request.StudentId);
                if (response != null)
                {
                    res.Remove(response);
                }

                _distributedCache.SetString("UniversityStudent", JsonConvert.SerializeObject(res));
            }

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