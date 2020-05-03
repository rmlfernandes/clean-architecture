namespace CleanArchitecture.Infrastructure.UnitTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoFixture;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Queries.GetCustomers;
    using CleanArchitecture.Domain.Entities;
    using CleanArchitecture.Infrastructure.Repositories;
    using FluentAssertions;
    using Xunit;

    public class CustomersRepositoryTests
    {
        private readonly ICustomersRepository repository;
        private readonly Fixture fixture;

        public CustomersRepositoryTests()
        {
            this.repository = new InMemoryCustomersRepository();
            this.fixture = new Fixture();
        }

        [Fact]
        public async Task CreateCustomerAsync_ValidCustomer_CustomerIdReturned()
        {
            // Arrange
            var customerId = Guid.Parse("A07372FB-474F-49CB-8576-50A8D84D0001");
            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            // Act
            var id = await this.repository.CreateCustomerAsync(customer);

            // Assert
            id.Should().NotBeEmpty();
            id.Should().Be(customerId);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ValidCustomerId_CustomerDeleted()
        {
            // Arrange
            var customerId = Guid.Parse("D05940B2-C70D-4C7D-913C-119B7DFEE586");
            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            var id = await this.repository.CreateCustomerAsync(customer);

            // Act
            Action act = () => this.repository.DeleteCustomerAsync(id);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public async Task GetCustomersAsync_EmptyQuery_AllCustomersReturned()
        {
            // Arrange
            const int CustomersCount = 10;
            var customers = this.fixture
                .CreateMany<Customer>(CustomersCount)
                .ToList();

            foreach (var customer in customers)
            {
                await this.repository.CreateCustomerAsync(customer);
            }

            // Act
            var result = await this.repository.GetCustomersAsync(new GetCustomersQuery());

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(CustomersCount);
        }

        [Fact]
        public async Task GetCustomerAsync_ValidCustomerId_CustomerReturned()
        {
            // Arrange
            var customerId = Guid.Parse("A6D238FB-7073-4FA5-B5E1-0EEE9DAF99E5");
            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            var id = await this.repository.CreateCustomerAsync(customer);

            // Act
            var result = await this.repository.GetCustomerAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ValidCustomer_CustomerUpdated()
        {
            // Arrange
            const string CustomerName = "John Doe";
            var customerId = Guid.Parse("23DE0132-748B-4FDA-BDCD-6A42E460E2D2");
            var customer = this.fixture
                .Build<Customer>()
                .With(c => c.Id, customerId)
                .Create();

            var id = await this.repository.CreateCustomerAsync(customer);

            // Act
            customer.Name = CustomerName;

            Action act = () => this.repository.UpdateCustomerAsync(customer);

            // Assert
            act.Should().NotThrow();
            var updatedResult = await this.repository.GetCustomerAsync(customerId);
            updatedResult.Name.Should().Be("John Doe");
        }
    }
}
