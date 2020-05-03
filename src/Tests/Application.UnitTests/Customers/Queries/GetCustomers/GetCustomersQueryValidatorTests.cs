using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Customers.Queries.GetCustomers;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryValidatorTests
    {
        [Fact]
        public async Task ValidateAsync_ValidQuery_ValidationResultIsValid()
        {
            // Arrange
            var validator = new GetCustomersQueryValidator();
            var query = new GetCustomersQuery(
                new List<Guid> { Guid.Parse("34DE200F-EDCF-4590-9BD1-00318E826164") },
                new List<string>(),
                new List<int>(),
                new List<long>(),
                new List<string>());

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
            var validator = new GetCustomersQueryValidator();
            var query = new GetCustomersQuery(
                new List<Guid> { Guid.Empty },
                new List<string>(),
                new List<int>(),
                new List<long>(),
                new List<string>());

            // Act
            var result = await validator.ValidateAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
