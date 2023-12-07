using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using University.Domain.Entities.Images;
using University.Domain.Entities.Students;
using University.Domain.Enums.Roles;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.PhoneNumber;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Students.Commands.Create;

namespace University.Service.UseCases.Students.Handlers.Create
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
            Student? checkPhoneNumber = await _context.Students.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Student? checkEmail = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);


            if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExists();
            else if (checkEmail != null)
                throw new EmailAlreadyExists();

            string imagePath = await _fileService.UploadImageAsync(request.Image);

            Student student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password),
                Address = request.Address,
                Birthdate = request.Birthdate,
                ImagePath = imagePath,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                Role = Role.Student,
                AddressTemporary = request.AddressTemporary,
                Salt = request.Salt,
                GroupId = request.GroupId,
                CreatedAt = DateTime.Now,
            };

            var res = await _context.Students.AddAsync(student, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            string? cache = _distributedCache.GetString("UniversityStudent");

            if (cache != null)
            {
                var deserializeObj = JsonConvert.DeserializeObject<List<ImageHelper>>(cache);

                deserializeObj.Add(new ImageHelper() { Id = res.Entity.StudentId, ImagePath = res.Entity.ImagePath });

                _distributedCache.Remove("UniversityStudent");

                _distributedCache.SetString("UniversityStudent", JsonConvert.SerializeObject(deserializeObj));
            }
            else
            {
                List<ImageHelper> strings = new List<ImageHelper>();
                strings.Add(new ImageHelper() { Id = res.Entity.StudentId, ImagePath = res.Entity.ImagePath });
                _distributedCache.SetString("UniversityStudent", JsonConvert.SerializeObject(strings));
            }

            return result;
        }
    }
}