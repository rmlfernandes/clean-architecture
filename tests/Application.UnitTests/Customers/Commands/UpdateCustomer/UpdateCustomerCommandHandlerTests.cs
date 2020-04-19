namespace CleanArchitecture.Application.UnitTests.Customers.Commands.UpdateCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoFixture;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Commands.UpdateCustomer;
    using CleanArchitecture.Domain.Entities;
    using Moq;
    using Xunit;

    public class UpdateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> repositoryMock;
        private readonly Mock<IIdentityService> identityServiceMock;

        private readonly UpdateCustomerCommandHandler handler;
        private readonly Fixture fixture;

        public UpdateCustomerCommandHandlerTests()
        {
            this.repositoryMock = new Mock<ICustomerRepository>();
            this.identityServiceMock = new Mock<IIdentityService>();

            this.handler = new UpdateCustomerCommandHandler(
                this.repositoryMock.Object,
                this.identityServiceMock.Object);

            this.fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_ValidCommand_CustomerRepositoryCalled()
        {
            // Arrange
            var customerId = Guid.Parse("B83806BA-41D7-4412-B20A-3E65518C970A");
            var command = new UpdateCustomerCommand
            {
                Id = customerId,
                PhoneNumber = 123456789,
                Website = "https://www.example.com"
            };
            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            this.identityServiceMock
                .Setup(s => s.GetUserIdentifierAsync())
                .ReturnsAsync(customerId);

            this.repositoryMock
                .Setup(r => r.GetCustomerAsync(command.Id))
                .ReturnsAsync(customer);

            this.repositoryMock
                .Setup(r => r.UpdateCustomerAsync(
                    It.Is<Customer>(
                        c => c.Id == command.Id
                        && c.PhoneNumber == command.PhoneNumber
                        && c.Website.OriginalString == command.Website)))
                .Returns(Task.CompletedTask);

            // Act
            await this.handler.Handle(command, CancellationToken.None);

            // Assert
            this.identityServiceMock.VerifyAll();
            this.repositoryMock.VerifyAll();
        }
    }
}
