using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Exceptions.Admins;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Admins.Queries.Get;

namespace School.Service.Abstractions.UseCases.Admins.Handlers.Get
{
    public class GetAdminByIdCommandHandler : IRequestHandler<GetAdminByIdQuery, Admin>
    {
        private readonly IApplicationDbContext _context;

        public GetAdminByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId,cancellationToken);

            if (admin == null)
                throw new AdminNotFound();

            return admin;
        }
    }
}

