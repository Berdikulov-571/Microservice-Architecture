using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Enums.RoleEnum;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Teachers.Commands.Create;
using School.Service.Interfaces.File;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Teachers.Handlers.Create
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateTeacherCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        async Task<int> IRequestHandler<CreateTeacherCommand, int>.Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? checkUserName = await _context.Teachers.FirstOrDefaultAsync(x => x.UserName == request.UserName,cancellationToken);
            Teacher? checkPhoneNumber = await _context.Teachers.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber,cancellationToken);
            Teacher? checkEmail = await _context.Teachers.FirstOrDefaultAsync(x => x.Email == request.Email,cancellationToken);

            if (checkUserName != null)
            {
                throw new UserNameAlreadyExistsException();
            }
            else if(checkPhoneNumber != null)
            {
                throw new PhoneNumberAlreadyExistsException();
            }
            else if(checkEmail != null)
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

            await _context.Teachers.AddAsync(teacher,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}