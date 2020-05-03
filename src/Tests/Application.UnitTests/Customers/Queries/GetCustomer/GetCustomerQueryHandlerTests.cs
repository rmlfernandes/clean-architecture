namespace CleanArchitecture.Application.UnitTests.Customers.Queries.GetCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoFixture;
    using CleanArchitecture.Application.Common.Exceptions;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Queries.GetCustomer;
    using CleanArchitecture.Domain.Entities;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class GetCustomerQueryHandlerTests
    {
        private readonly Mock<ICustomerRepository> repositoryMock;

        private readonly GetCustomerQueryHandler handler;
        private readonly Fixture fixture;

        public GetCustomerQueryHandlerTests()
        {
            this.repositoryMock = new Mock<ICustomerRepository>();

            this.handler = new GetCustomerQueryHandler(this.repositoryMock.Object);
            this.fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_ExistentCustomer_CustomerReturned()
        {
            // Arrange
            var customerId = Guid.Parse("835D6C36-215E-4F5B-8084-3B8C1B7C59EC");
            var query = new GetCustomerQuery
            {
                Id = customerId
            };

            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            this.repositoryMock
                .Setup(r => r.GetCustomerAsync(query.Id))
                .ReturnsAsync(customer);

            // Act
            var result = await this.handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(customerId);
            this.repositoryMock.VerifyAll();
        }

        [Fact]
        public async Task Handle_InexistentCustomer_NotFoundExceptionThrown()
        {
            // Arrange
            var customerId = Guid.Parse("835D6C36-215E-4F5B-8084-3B8C1B7C59EC");
            var query = new GetCustomerQuery
            {
                Id = customerId
            };

            this.repositoryMock
                .Setup(r => r.GetCustomerAsync(query.Id))
                .ReturnsAsync(default(Customer));

            // Act
            Func<Task> act = async () => await this.handler.Handle(query, CancellationToken.None);

            // Assert
            act.Should().ThrowExactly<NotFoundException>();
            this.repositoryMock.VerifyAll();
        }
    }
}
