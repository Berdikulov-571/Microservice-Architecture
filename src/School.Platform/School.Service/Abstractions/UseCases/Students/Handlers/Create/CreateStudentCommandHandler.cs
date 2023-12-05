using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Students.Commands.Create;
using School.Service.Interfaces.File;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Students.Handlers.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateStudentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? checkUserName = await _context.Students.FirstOrDefaultAsync(x => x.UserName == request.UserName,cancellationToken);
            Student? checkPhoneNumber = await _context.Students.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber,cancellationToken);
            Student? checkEmail = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email,cancellationToken);

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

            await _context.Students.AddAsync(student,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}