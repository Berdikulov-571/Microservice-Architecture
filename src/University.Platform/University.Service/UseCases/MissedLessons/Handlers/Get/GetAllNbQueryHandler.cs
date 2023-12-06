using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.MissedLessons;
using University.Domain.Exceptions.MissedLessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.MissedLessons.Queries.Get;

namespace University.Service.UseCases.MissedLessons.Handlers.Get
{
    public class GetAllNbQueryHandler : IRequestHandler<GetAllNbQuery, IEnumerable<NB>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNbQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NB>> Handle(GetAllNbQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<NB> nbs = await _context.Nbs.ToListAsync(cancellationToken);

            if (nbs == null)
                throw new NbNotFound();

            return nbs;
        }
    }
}