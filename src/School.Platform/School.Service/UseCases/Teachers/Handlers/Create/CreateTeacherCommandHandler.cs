using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Dtos.Images;
using School.Domain.Entities.Students;
using School.Domain.Entities.Teachers;
using School.Domain.Enums.RoleEnum;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.Security.Password;
using School.Service.UseCases.Teachers.Commands.Create;

namespace School.Service.UseCases.Teachers.Handlers.Create
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDistributedCache _distributedCache;


        public CreateTeacherCommandHandler(IApplicationDbContext context, IFileService fileService, IDistributedCache distributedCache)
        {
            _context = context;
            _fileService = fileService;
            _distributedCache = distributedCache;
        }

        async Task<int> IRequestHandler<CreateTeacherCommand, int>.Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? checkUserName = await _context.Teachers.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
            Teacher? checkPhoneNumber = await _context.Teachers.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Teacher? checkEmail = await _context.Teachers.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkUserName != null)
            {
                throw new UserNameAlreadyExistsException();
            }
            else if (checkPhoneNumber != null)
            {
                throw new PhoneNumberAlreadyExistsException();
            }
            else if (checkEmail != null)
            {
                throw new EmailAlreadyExistsException();
            }

            string imagePath = await _fileService.UploadImageAsync(request.ImagePath);

            Teacher teacher = new Teacher()
            {
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                ImagePath = imagePath,
                Address = request.Address,
                Role = Role.Teacher,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.PasswordHash),
                CreatedAt = DateTime.Now,
            };

            var res = await _context.Teachers.AddAsync(teacher, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);


            string? cache = _distributedCache.GetString("Teacher");

            if (cache != null)
            {
                var deserializeObj = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                deserializeObj.Add(new ImageHelper() { Id = res.Entity.TeacherId, ImagePath = res.Entity.ImagePath });

                _distributedCache.Remove("Teacher");

                _distributedCache.SetString("Teacher", JsonConvert.SerializeObject(deserializeObj));
            }
            else
            {
                List<ImageHelper> strings = new List<ImageHelper>();
                strings.Add(new ImageHelper() { Id = res.Entity.TeacherId, ImagePath = res.Entity.ImagePath });
                _distributedCache.SetString("Teacher", JsonConvert.SerializeObject(strings));
            }

            return result;
        }
    }
}