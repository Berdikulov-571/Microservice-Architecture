using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Transports.Commands;
using PublicTransport.Service.UseCases.Transports.Handlers;

namespace Transport.Platform.UnitTesting
{
    public class TransportCreateUnitTesting : IClassFixture<DependecyInjection>
    {
        private readonly IApplicationDbContext _context;

        public TransportCreateUnitTesting(DependecyInjection dependecyInjection)
        {
            _context = dependecyInjection.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        }

        [Fact]
        public async ValueTask CreateTrasnport()
        {
            var mediatorMock = new Mock<IMediator>();
            var handler = new CreateTransportCommandHandler(_context);
            var createProductCommand = new CreateTransportCommand()
            {
                Capacity = 1,
                TransportName = "Test",
                TransportType = "12"
            };
            int expectedResult = 1;

            // Act
            var result = await handler.Handle(createProductCommand, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async ValueTask DeleteAsync()
        {
            var mediatorMock = new Mock<IMediator>();
            var handler = new DeleteTransportCommandHandler(_context);
            var deleteTransportCommand = new DeleteTransportCommand()
            {
                TransportId = 1
            };

            int expectedResult = 1;

            int result = await handler.Handle(deleteTransportCommand, CancellationToken.None);

            Assert.Equal(expectedResult, result);
        }
    }
}