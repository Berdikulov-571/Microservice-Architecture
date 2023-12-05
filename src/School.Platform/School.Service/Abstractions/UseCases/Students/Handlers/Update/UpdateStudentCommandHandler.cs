using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Students.Commands.Update;
using School.Service.Interfaces.File;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Students.Handlers.Update
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateStudentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

            if (student == null)
                throw new StudentNotFound();

            Student? checkUserName = await _context.Students.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
            Student? checkPhoneNumber = await _context.Students.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Student? checkEmail = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkUserName != null)
                throw new UserNameAlreadyExistsException();
            else if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExistsException();
            else if (checkEmail != null)
                throw new EmailAlreadyExistsException();

            student.UserName = request.UserName;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password);
            student.Address = request.Address;
            student.DateOfBirth = request.DateOfBirth;
            student.ClassId = request.ClassId;
            student.Gender = request.Gender;
            student.PhoneNumber = request.PhoneNumber;
            student.Role = Domain.Enums.RoleEnum.Role.Student;
            student.UpdatedAt = DateTime.Now;

            if (request.Image != null)
            {
                await _fileService.DeleteImageAsync(student.ImagePath);
                student.ImagePath = await _fileService.UploadImageAsync(request.Image);
            }

            _context.Students.Update(student);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}