using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Groups;
using University.Domain.Exceptions.Groups;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Groups.Commands.Update;

namespace University.Service.UseCases.Groups.Handlers.Update
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            Group? group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == request.GroupId,cancellationToken);

            if (group == null)
                throw new GroupNotFound();

            group.Level = request.Level;
            group.Name = request.Name;
            group.UpdateAt = DateTime.Now;

            _context.Groups.Update(group);

            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
