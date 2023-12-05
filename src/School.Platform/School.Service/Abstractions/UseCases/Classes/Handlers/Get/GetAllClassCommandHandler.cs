using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Classes;
using School.Domain.Exceptions.Classes;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Classes.Queries.Get;

namespace School.Service.Abstractions.UseCases.Classes.Handlers.Get
{
    public class GetAllClassCommandHandler : IRequestHandler<GetAllClassQuery, IEnumerable<Class>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> Handle(GetAllClassQuery request, CancellationToken cancellationToken)
        {
            List<Class> result = await _context.Classes.ToListAsync(cancellationToken);

            if (result == null)
                throw new ClassNotFound();

            return result;
        }
    }
}