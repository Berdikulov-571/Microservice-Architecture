using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.MissedLessons;
using University.Domain.Exceptions.MissedLessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.MissedLessons.Queries.Get;

namespace University.Service.UseCases.MissedLessons.Handlers.Get
{
    public class GetNbByIdQueryHandler : IRequestHandler<GetnbByIdQuery, NB>
    {
        private readonly IApplicationDbContext _context;

        public GetNbByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NB> Handle(GetnbByIdQuery request, CancellationToken cancellationToken)
        {
            NB? nb = await _context.Nbs.FirstOrDefaultAsync(x => x.NbId == request.NbId, cancellationToken);

            if (nb == null)
                throw new NbNotFound();

            return nb;
        }
    }
}
