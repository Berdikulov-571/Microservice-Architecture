using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Dtos.Images;
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

            string? cache = _distributedCache.GetString("Student");

            if (cache != null)
            {
                var res = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);
                var response = res.FirstOrDefault(x => x.Id == request.StudentId);
                if (response != null)
                {
                    res.Remove(response);
                }

                _distributedCache.SetString("Student",JsonConvert.SerializeObject(res));
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
