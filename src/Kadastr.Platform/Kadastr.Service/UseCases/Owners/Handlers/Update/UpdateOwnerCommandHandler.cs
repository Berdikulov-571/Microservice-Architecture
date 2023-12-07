using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Commands.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Service.UseCases.Owners.Handlers.Update
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOwnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.OwnerID == request.OwnerID,cancellationToken);

            owner.OwnerName = request.OwnerName;
            owner.UpdatedAt = DateTime.Now;
            owner.ContactInfo = request.ContactInfo;

            _context.Owners.Update(owner);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}