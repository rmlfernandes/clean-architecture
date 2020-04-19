namespace CleanArchitecture.Application.UnitTests.Customers.Commands.DeleteCustomer
{
    using System;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Commands.DeleteCustomer;
    using FluentAssertions;
    using Xunit;

    public class DeleteCustomerCommandValidatorTests
    {
        [Fact]
        public async Task ValidateAsync_ValidCommand_ValidationResultIsValid()
        {
            // Arrange
            var validator = new DeleteCustomerCommandValidator();
            var command = new DeleteCustomerCommand
            {
                Id = Guid.Parse("7DE0930E-45AA-4B0F-BE3A-9359600DB1C5")
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
            var validator = new DeleteCustomerCommandValidator();
            var command = new DeleteCustomerCommand();

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
