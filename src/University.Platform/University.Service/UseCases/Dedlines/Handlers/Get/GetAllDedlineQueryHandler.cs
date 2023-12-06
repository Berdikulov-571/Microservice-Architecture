using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Dedlines;
using University.Domain.Exceptions.Dedlines;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Dedlines.Queries.Get;

namespace University.Service.UseCases.Dedlines.Handlers.Get
{
    public class GetAllDedlineQueryHandler : IRequestHandler<GetAllDedlineQuery, IEnumerable<Dedline>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDedlineQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dedline>> Handle(GetAllDedlineQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Dedline> dedlines = await _context.Dedlines.ToListAsync(cancellationToken);

            if (dedlines == null)
                throw new DedlineNotFound();

            return dedlines;
        }
    }
}