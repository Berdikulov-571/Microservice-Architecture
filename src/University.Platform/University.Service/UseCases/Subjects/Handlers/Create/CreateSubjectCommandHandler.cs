using MediatR;
using University.Domain.Entities.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Commands.Create;

namespace University.Service.UseCases.Subjects.Handlers.Create
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject subject = new Subject()
            {
                Name = request.Name,
                CreatedAt = DateTime.Now,
            };

            await _context.Subjects.AddAsync(subject, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}