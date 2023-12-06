using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Dedlines;
using University.Domain.Exceptions.Dedlines;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Dedlines.Queries.Get;

namespace University.Service.UseCases.Dedlines.Handlers.Get
{
    public class GetDedlineByIdQueryHandler : IRequestHandler<GetDedlineByIdQuery, Dedline>
    {
        private readonly IApplicationDbContext _context;

        public GetDedlineByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dedline> Handle(GetDedlineByIdQuery request, CancellationToken cancellationToken)
        {
            Dedline? dedline = await _context.Dedlines.FirstOrDefaultAsync(x => x.DedlineId == request.DedlineId,cancellationToken);

            if (dedline == null)
                throw new DedlineNotFound();

            return dedline;
        }
    }
}