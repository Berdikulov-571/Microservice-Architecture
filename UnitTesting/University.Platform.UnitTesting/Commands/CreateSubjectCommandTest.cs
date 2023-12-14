using Microsoft.Extensions.DependencyInjection;
using University.Domain.Exceptions.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Commands.Create;
using University.Service.UseCases.Subjects.Handlers.Create;

namespace University.Platform.UnitTesting.Commands
{
    public class CreateSubjectCommandTest : IClassFixture<DependecyInjection>
    {
        private readonly IApplicationDbContext _context;
        public CreateSubjectCommandTest(DependecyInjection dependecyInjection)
        {
            _context = dependecyInjection.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        }


        public async Task Create_Subject_Command()
        {
            // Arrange  
            var cancellationToken = new CancellationTokenSource().Token;
            CreateSubjectCommand command = new CreateSubjectCommand()
            {
                Name = "Test"
            };

            CreateSubjectCommandHandler handler = new CreateSubjectCommandHandler(_context);

            // Act
            Action result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            Assert.Throws<SubjectAlreadyExists>(result);
        }
    }
}