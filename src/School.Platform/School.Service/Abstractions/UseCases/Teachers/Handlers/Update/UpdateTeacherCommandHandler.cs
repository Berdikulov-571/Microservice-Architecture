using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Teachers.Commands.Update;
using School.Service.Interfaces.File;
using School.Service.Security.Password;

namespace School.Service.Abstractions.UseCases.Teachers.Handlers.Update
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

            teacher.UserName = request.UserName;
            teacher.Email = request.Email;
            teacher.PhoneNumber = request.PhoneNumber;
            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Address = request.Address;
            teacher.DateOfBirth = request.DateOfBirth;
            teacher.UpdatedAt = DateTime.Now;
            teacher.Gender = request.Gender;
            teacher.PasswordHash = Hash512.ComputeSHA512HashFromString(request.PasswordHash);

            if(request.ImagePath != null)
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