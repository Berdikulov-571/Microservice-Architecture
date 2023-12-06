using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.PhoneNumber;
using University.Domain.Exceptions.Teachers;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Teachers.Commands.Update;

namespace University.Service.UseCases.Teachers.Handlers.Update
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateTeacherCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId,cancellationToken);

            if (teacher == null)
                throw new TeacherNotFound();

            Teacher? checkEmail = await _context.Teachers.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            Teacher? checkPhoneNumber = await _context.Teachers.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (checkEmail != null)
                throw new EmailAlreadyExists();
            else if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExists();

            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Email = request.Email;
            teacher.PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password);
            teacher.Address = request.Address;
            teacher.AddressTemporary = request.AddressTemporary;
            teacher.Gender = request.Gender;
            teacher.Salt = request.Salt;
            teacher.Birthdate = request.Birthdate;
            teacher.PhoneNumber = request.PhoneNumber;

            if (request.ImagePath != null)
            {
                await _fileService.DeleteImageAsync(teacher.ImagePath);
                teacher.ImagePath = await _fileService.UploadImageAsync(request.ImagePath);
            }

            _context.Teachers.Update(teacher);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}