using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Dtos.Images;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.Security.Password;
using School.Service.UseCases.Students.Commands.Create;

namespace School.Service.UseCases.Students.Handlers.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDistributedCache _distributedCache;

        public CreateStudentCommandHandler(IApplicationDbContext context, IFileService fileService, IDistributedCache distributedCache)
        {
            _context = context;
            _fileService = fileService;
            _distributedCache = distributedCache;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? checkUserName = await _context.Students.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
            Student? checkPhoneNumber = await _context.Students.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Student? checkEmail = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkUserName != null)
                throw new UserNameAlreadyExistsException();
            else if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExistsException();
            else if (checkEmail != null)
                throw new EmailAlreadyExistsException();

            string imagePath = await _fileService.UploadImageAsync(request.Image);

              

            Student student = new Student()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password),
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                ClassId = request.ClassId,
                CreatedAt = DateTime.Now,
                ImagePath = imagePath,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                Role = Domain.Enums.RoleEnum.Role.Student,
            };


            var res = await _context.Students.AddAsync(student, cancellationToken);

            int result = await _context.SaveChangesAsync(cancellationToken);


            string? cache = _distributedCache.GetString("Student");

            if (cache != null)
            {
                var deserializeObj = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                deserializeObj.Add(new ImageHelper() { Id = res.Entity.StudentId,ImagePath = res.Entity.ImagePath });

                _distributedCache.Remove("Student");

                _distributedCache.SetString("Student", JsonConvert.SerializeObject(deserializeObj));
            }
            else
            {
                List<ImageHelper> strings = new List<ImageHelper>();
                strings.Add(new ImageHelper() { Id = res.Entity.StudentId, ImagePath = res.Entity.ImagePath });
                _distributedCache.SetString("Student", JsonConvert.SerializeObject(strings));
            }
           
            return result;
        }
    }
}