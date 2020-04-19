namespace CleanArchitecture.Application.UnitTests.Customers.Commands.CreateCustomer
{
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Commands.CreateCustomer;
    using FluentAssertions;
    using Xunit;

    public class CreateCustomerCommandValidatorTests
    {
        [Fact]
        public async Task ValidateAsync_ValidCommand_ValidationResultIsValid()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand
            {
                Name = "John Doe",
                Age = 30,
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
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand
            {
                Name = "John Doe"
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
