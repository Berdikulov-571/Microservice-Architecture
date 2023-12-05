using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Classes;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Classes.Commands.Create;

namespace School.Service.Abstractions.UseCases.Classes.Handlers.Create
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            Class? @class = await _context.Classes.FirstOrDefaultAsync(x => x.ClassTeacher == request.ClassTeacherId, cancellationToken);

            if (@class != null)
            {
                throw new TeacherAlreadyExistsException();
            }

            Class resultClass = new Class()
            {
                Name = request.Name,
                RoomNumber = request.RoomNumber,
                ClassTeacher = request.ClassTeacherId,
            };

            await _context.Classes.AddAsync(resultClass,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}