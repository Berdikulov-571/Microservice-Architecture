using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Exceptions.Admins;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Admins.Queries.Get;

namespace University.Service.UseCases.Admins.Handlers.Get
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, Admin>
    {
        private readonly IApplicationDbContext _context;

        public GetAdminByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
                throw new AdminNotFound();

            return admin;
        }
    }
}