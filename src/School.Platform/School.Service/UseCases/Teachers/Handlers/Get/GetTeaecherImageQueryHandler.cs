using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Dtos.Images;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Image;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.UseCases.Teachers.Queries.Get;

namespace School.Service.UseCases.Teachers.Handlers.Get
{
    public class GetTeaecherImageQueryHandler : IRequestHandler<GetTeacherImageQuery, byte[]>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _distributedCache;


        public GetTeaecherImageQueryHandler(IFileService fileService, IApplicationDbContext context, IDistributedCache distributedCache)
        {
            _fileService = fileService;
            _context = context;
            _distributedCache = distributedCache;
        }

        public async Task<byte[]> Handle(GetTeacherImageQuery request, CancellationToken cancellationToken)
        {
            string? cache = _distributedCache.GetString("Teacher");

            if (cache != null)
            {
                List<ImageHelper>? result = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                ImageHelper? student = result.FirstOrDefault(x => x.Id == request.TeacherId);

                if (student != null)
                {
                    byte[] byteImage = await _fileService.GetImageAsync(student.ImagePath);

                    return byteImage;
                }
                throw new ImageNotFound();
            }
            else
            {
                Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId);

                if (teacher == null)
                    throw new TeacherNotFound();
                else if (teacher.ImagePath == null)
                    throw new ImageNotFound();

                byte[] image = await _fileService.GetImageAsync(teacher.ImagePath);

                return image;
            }
        }
    }
}