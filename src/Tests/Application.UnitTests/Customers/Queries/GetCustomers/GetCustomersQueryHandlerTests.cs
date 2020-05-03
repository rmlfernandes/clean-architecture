namespace CleanArchitecture.Application.UnitTests.Customers.Queries.GetCustomers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoFixture;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Queries;
    using CleanArchitecture.Application.Customers.Queries.GetCustomers;
    using CleanArchitecture.Domain.Entities;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class GetCustomersQueryHandlerTests
    {
        private readonly Mock<ICustomerRepository> repositoryMock;

        private readonly GetCustomersQueryHandler handler;
        private readonly Fixture fixture;

        public GetCustomersQueryHandlerTests()
        {
            this.repositoryMock = new Mock<ICustomerRepository>();

            this.handler = new GetCustomersQueryHandler(this.repositoryMock.Object);
            this.fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_ValidQuery_CustomersReturned()
        {
            // Arrange
            const int customersCount = 10;
            var query = new GetCustomersQuery();
            var customers = this.fixture
                .Build<Customer>()
                .CreateMany(customersCount)
                .ToList();

            this.repositoryMock
                .Setup(r => r.GetCustomersAsync(It.IsAny<GetCustomersQuery>()))
                .ReturnsAsync(customers);

            // Act
            var result = await this.handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CustomerDto>();
            this.repositoryMock.VerifyAll();
        }
    }
}
