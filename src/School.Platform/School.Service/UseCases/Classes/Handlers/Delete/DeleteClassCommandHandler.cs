using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Classes;
using School.Domain.Exceptions.Classes;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Classes.Commands.Delete;

namespace School.Service.UseCases.Classes.Handlers.Delete
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            Class? @class = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == request.ClassId, cancellationToken);

            if (@class == null)
                throw new ClassNotFound();

            _context.Classes.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}