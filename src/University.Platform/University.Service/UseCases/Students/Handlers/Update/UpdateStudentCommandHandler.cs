using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Email;
using University.Domain.Exceptions.PhoneNumber;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.Interfaces.File;
using University.Service.Security.Password;
using University.Service.UseCases.Students.Commands.Update;

namespace University.Service.UseCases.Students.Handlers.Update
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

            Student? checkPhoneNumber = await _context.Students.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            Student? checkEmail = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkPhoneNumber != null)
                throw new PhoneNumberAlreadyExists();
            else if (checkEmail != null)
                throw new EmailAlreadyExists();

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.PasswordHash = Hash512.ComputeSHA512HashFromString(request.Password);
            student.Address = request.Address;
            student.Birthdate = request.Birthdate;
            student.Gender = request.Gender;
            student.PhoneNumber = request.PhoneNumber;
            student.AddressTemporary = request.AddressTemporary;
            student.Salt = request.Salt;
            student.GroupId = request.GroupId;
            student.UpdateAt = DateTime.Now;

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