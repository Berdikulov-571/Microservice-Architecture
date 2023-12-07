using Kadastr.Domain.Entities.Owners;
using Kadastr.Service.Abstractions.Data;
using Kadastr.Service.UseCases.Owners.Commands.Create;
using MediatR;

namespace Kadastr.Service.UseCases.Owners.Handlers.Create
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOwnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            Owner owner = new Owner()
            {
                OwnerName = request.OwnerName,
                ContactInfo = request.ContactInfo,
                CreatedAt = DateTime.Now,
            };

            await _context.Owners.AddAsync(owner,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}