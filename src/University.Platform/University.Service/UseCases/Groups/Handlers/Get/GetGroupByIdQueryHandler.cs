using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Groups;
using University.Domain.Exceptions.Groups;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Groups.Queries.Get;

namespace University.Service.UseCases.Groups.Handlers.Get
{
    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, Group>
    {
        private readonly IApplicationDbContext _context;

        public GetGroupByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            Group? group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == request.GroupId,cancellationToken);

            if (group == null)
                throw new GroupNotFound();

            return group;
        }
    }
}