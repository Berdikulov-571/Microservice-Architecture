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
using University.Service.UseCases.Students.Queries.Get;

namespace University.Service.UseCases.Students.Handlers.Get
{
    public class GetStudentImageQueryHandler : IRequestHandler<GetStudentImageQuery, byte[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDistributedCache _distributedCache;


        public GetStudentImageQueryHandler(IApplicationDbContext context, IFileService fileService, IDistributedCache distributedCache)
        {
            _context = context;
            _fileService = fileService;
            _distributedCache = distributedCache;
        }

        public async Task<byte[]> Handle(GetStudentImageQuery request, CancellationToken cancellationToken)
        {
            string? cache = _distributedCache.GetString("UniversityStudent");

            if (cache != null)
            {
                List<ImageHelper>? result = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                ImageHelper? student = result.FirstOrDefault(x => x.Id == request.StudentId);

                if (student != null)
                {
                    byte[] image = await _fileService.GetImageAsync(student.ImagePath);

                    return image;
                }
                throw new ImageNotFound();

            }
            else
            {
                Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

                if (student == null)
                    throw new StudentNotFound();
                else if (student.ImagePath == null)
                    throw new ImageNotFound();

                byte[] image = await _fileService.GetImageAsync(student.ImagePath);

                return image;
            }
        }
    }
}