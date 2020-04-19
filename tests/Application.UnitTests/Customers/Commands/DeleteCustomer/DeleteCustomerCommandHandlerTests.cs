namespace CleanArchitecture.Application.UnitTests.Customers.Commands.DeleteCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Commands.DeleteCustomer;
    using Moq;
    using Xunit;

    public class DeleteCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> repositoryMock;

        private readonly DeleteCustomerCommandHandler handler;

        public DeleteCustomerCommandHandlerTests()
        {
            this.repositoryMock = new Mock<ICustomerRepository>();

            this.handler = new DeleteCustomerCommandHandler(this.repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_CustomerRepositoryCalled()
        {
            // Arrange
            var customerId = Guid.Parse("B83806BA-41D7-4412-B20A-3E65518C970A");
            var command = new DeleteCustomerCommand
            {
                Id = customerId
            };

            this.repositoryMock
                .Setup(r => r.DeleteCustomerAsync(customerId))
                .Returns(Task.CompletedTask);

            // Act
            await this.handler.Handle(command, CancellationToken.None);

            // Assert
            this.repositoryMock.VerifyAll();
        }
    }
}
