using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Exceptions.Admins;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Admins.Queries.Get;

namespace School.Service.UseCases.Admins.Handlers.Get
{
    public class GetAllAdminCommandHandler : IRequestHandler<GetAllAdminQuery, IEnumerable<Admin>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdminCommandHandler(IApplicationDbContext context)
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