using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Enums.Roles;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.PhoneNumber;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Teachers.Commands.Create;

namespace University.Service.UseCases.Teachers.Handlers.Create
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

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? checkPhoneNumber = await _context.Teachers.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Teacher? checkEmail = await _context.Teachers.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExists();
            else if (checkEmail != null)
                throw new EmailAlreadyExists();

            string imagePath = await _fileService.UploadImageAsync(request.Image);

            Teacher teacher = new Teacher()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password),
                Address = request.Address,
                AddressTemporary = request.AddressTemporary,
                ImagePath = imagePath,
                Gender = request.Gender,
                Salt = request.Salt,
                Role = Role.Teacher,
                Birthdate = request.Birthdate,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.Now,
            };

            await _context.Teachers.AddAsync(teacher, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}