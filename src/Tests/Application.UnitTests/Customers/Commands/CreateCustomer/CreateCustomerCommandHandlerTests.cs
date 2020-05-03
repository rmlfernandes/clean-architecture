namespace CleanArchitecture.Application.UnitTests.Customers.Commands.CreateCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Commands.CreateCustomer;
    using CleanArchitecture.Domain.Entities;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomersRepository> repositoryMock;
        private readonly Mock<IIdentityService> identityServiceMock;

        private readonly CreateCustomerCommandHandler handler;

        public CreateCustomerCommandHandlerTests()
        {
            this.repositoryMock = new Mock<ICustomersRepository>();
            this.identityServiceMock = new Mock<IIdentityService>();

            this.handler = new CreateCustomerCommandHandler(
                this.repositoryMock.Object,
                this.identityServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_CustomerRepositoryCalled()
        {
            // Arrange
            var customerId = Guid.Parse("B83806BA-41D7-4412-B20A-3E65518C970A");
            var command = new CreateCustomerCommand
            {
                Name = "John Doe",
                Age = 30
            };

            this.identityServiceMock
                .Setup(s => s.GetUserIdentifierAsync())
                .ReturnsAsync(customerId);

            this.repositoryMock
                .Setup(r => r.CreateCustomerAsync(
                    It.Is<Customer>(c => c.Name == command.Name && c.Age == command.Age)))
                .ReturnsAsync(customerId);

            // Act
            var result = await this.handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(customerId);
            this.identityServiceMock.VerifyAll();
            this.repositoryMock.VerifyAll();
        }
    }
}
