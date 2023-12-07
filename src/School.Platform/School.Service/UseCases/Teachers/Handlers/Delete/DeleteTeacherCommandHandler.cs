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
using School.Service.UseCases.Teachers.Commands.Delete;

namespace School.Service.UseCases.Teachers.Handlers.Delete
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDistributedCache _distributedCache;


        public DeleteTeacherCommandHandler(IApplicationDbContext context, IFileService formFile, IDistributedCache distributedCache)
        {
            _context = context;
            _fileService = formFile;
            _distributedCache = distributedCache;
        }

        public async Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId, cancellationToken);

            if (teacher == null)
            {
                throw new TeacherNotFound();
            }

            string? cache = _distributedCache.GetString("Teacher");

            if (cache != null)
            {
                var res = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);
                var response = res.FirstOrDefault(x => x.Id == request.TeacherId);
                if(response != null)
                {
                    res.Remove(response);
                }

                _distributedCache.SetString("Teacher", JsonConvert.SerializeObject(res));
            }


            try
            {
                await _fileService.DeleteImageAsync(teacher.ImagePath);
            }
            catch
            {
                throw new ImageNotFound();
            }

            _context.Teachers.Remove(teacher);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
