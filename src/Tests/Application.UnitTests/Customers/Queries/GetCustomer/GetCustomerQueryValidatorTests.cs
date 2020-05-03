namespace CleanArchitecture.Application.UnitTests.Customers.Queries.GetCustomer
{
    using System;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Queries.GetCustomer;
    using FluentAssertions;
    using Xunit;

    public class GetCustomerQueryValidatorTests
    {
        [Fact]
        public async Task ValidateAsync_ValidQuery_ValidationResultIsValid()
        {
            // Arrange
            var validator = new GetCustomerQueryValidator();
            var query = new GetCustomerQuery
            {
                Id = Guid.Parse("00FBEE01-0E79-406A-B9BF-100AA0DC724C")
            };

            // Act
            var result = await validator.ValidateAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task ValidateAsync_InvalidQuery_ValidationResultIsNotValid()
        {
            // Arrange
            var validator = new GetCustomerQueryValidator();
            var query = new GetCustomerQuery();

            // Act
            var result = await validator.ValidateAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
