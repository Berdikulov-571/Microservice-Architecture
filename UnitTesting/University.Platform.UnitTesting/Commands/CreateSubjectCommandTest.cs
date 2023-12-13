using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using University.Service.Abstractions.DataContexts;

namespace University.Platform.UnitTesting.Commands
{
    public class CreateSubjectCommandTest : IClassFixture<DependecyInjection>
    {
        private readonly IApplicationDbContext _context;
        public CreateSubjectCommandTest(DependecyInjection dependecyInjection)
        {
            _context = dependecyInjection.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        }


        //[Fact]
        //public async Task Create_Subject_Command()
        //{
            //// Arrange
            //var cancellationToken = new CancellationTokenSource().Token;
            //CreateSubjectCommand command = new CreateSubjectCommand()
            //{
            //    Name = name
            //};

            //  CreateSubjectCommandHandler handler = new CreateSubjectCommandHandler(_context);

            //// Act
            //Action result = async () => await handler.Handle(command, cancellationToken);

            //// Assert
            //Assert.Throws<SubjectAlreadyExists>(result);
        //}
    }
}