using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Classes;
using School.Domain.Exceptions.Classes;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Classes.Queries.Get;

namespace School.Service.Abstractions.UseCases.Classes.Handlers.Get
{
    public class GetClassByIdCommandHandler : IRequestHandler<GetClassByIdQuery, Class>
    {
        private readonly IApplicationDbContext _context;

        public GetClassByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Class> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            Class? @class = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == request.ClassId, cancellationToken);

            if (@class == null)
                throw new ClassNotFound();

            return @class;
        }
    }
}