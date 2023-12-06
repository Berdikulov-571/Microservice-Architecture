using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Exceptions.Admins;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Admins.Queries.Get;

namespace University.Service.UseCases.Admins.Handlers.Get
{
    public class GetAllAdminQueryHandler : IRequestHandler<GetAllAdminQuery, IEnumerable<Admin>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdminQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
        {
            List<Admin> admins = await _context.Admins.ToListAsync(cancellationToken);

            if (admins == null)
                throw new AdminNotFound();

            return admins;
        }
    }
}