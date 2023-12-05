using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Subjects.Commands.Create;

namespace School.Service.UseCases.Subjects.Handlers.Create
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject? checkSubject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);

            if (checkSubject != null)
                throw new SubjectAlreadyExistsException();

            Subject subject = new Subject()
            {
                Name = request.Name,
            };

            await _context.Subjects.AddAsync(subject,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}