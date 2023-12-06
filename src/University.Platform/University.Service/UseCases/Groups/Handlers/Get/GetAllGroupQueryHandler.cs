using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Groups;
using University.Domain.Exceptions.Groups;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Groups.Queries.Get;

namespace University.Service.UseCases.Groups.Handlers.Get
{
    public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQuery, IEnumerable<Group>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllGroupQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Group> groups = await _context.Groups.ToListAsync(cancellationToken);

            if (groups == null)
                throw new GroupNotFound();

            return groups;
        }
    }
}