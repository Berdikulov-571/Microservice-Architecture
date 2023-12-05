using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Classes;
using School.Domain.Exceptions.Classes;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Classes.Commands.Update;

namespace School.Service.Abstractions.UseCases.Classes.Handlers.Update
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            Class? @class = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == request.ClassId, cancellationToken);

            if (@class == null)
                throw new ClassNotFound();

            @class.Name = request.Name;
            @class.RoomNumber = request.RoomNumber;
            @class.ClassTeacher = request.ClassTeacherId;

            _context.Classes.Update(@class);
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}