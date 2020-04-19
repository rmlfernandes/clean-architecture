namespace CleanArchitecture.Application.UnitTests.Customers.Commands.UpdateCustomer
{
    using System;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Commands.UpdateCustomer;
    using FluentAssertions;
    using Xunit;

    public class UpdateCustomerCommandValidatorTests
    {
        [Fact]
        public async Task ValidateAsync_ValidCommand_ValidationResultIsValid()
        {
            // Arrange
            var validator = new UpdateCustomerCommandValidator();
            var command = new UpdateCustomerCommand
            {
                Id = Guid.Parse("2DEE6F31-67F4-43E1-A944-9672B03B257C"),
                PhoneNumber = 123456789,
                Website = "https://www.example.com"
            };

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task ValidateAsync_InvalidCommand_ValidationResultIsNotValid()
        {
            // Arrange
            var validator = new UpdateCustomerCommandValidator();
            var command = new UpdateCustomerCommand
            {
                PhoneNumber = 123456789
            };

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
