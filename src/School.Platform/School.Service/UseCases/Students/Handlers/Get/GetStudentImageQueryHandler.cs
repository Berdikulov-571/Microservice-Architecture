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
using School.Service.UseCases.Students.Queries.Get;

namespace School.Service.UseCases.Students.Handlers.Get
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
            string? cache = _distributedCache.GetString("Student");

            if (cache != null)
            {
                List<ImageHelper>? result = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                ImageHelper? student =  result.FirstOrDefault(x => x.Id == request.StudentId);

                if(student != null)
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