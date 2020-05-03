namespace CleanArchitecture.Domain.UnitTests
{
    using System;
    using CleanArchitecture.Domain.Entities;
    using CleanArchitecture.Domain.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class CustomerTests
    {
        [Fact]
        public void UpdateWebsite_ValidWebsite_CustomerWebsiteUpdated()
        {
            // Arrange
            const string Website = "https://www.example.com";
            var customer = new Customer
            {
                Id = Guid.Parse("81FFA7BD-2A0C-489D-98F1-5FCF5BC5278B"),
                Name = "John Doe",
                Age = 30
            };

            // Act
            customer.UpdateWebsite(Website);

            // Assert
            customer.Website.Should().Be(Website);
        }

        [Fact]
        public void UpdatePhoneNumber_ValidPhoneNumber_CustomerPhoneNumberUpdated()
        {
            // Arrange
            const int PhoneNumber = 123456789;
            var customer = new Customer
            {
                Id = Guid.Parse("A2292AE9-C00E-4402-A4A0-CDE6D33EA8F1"),
                Name = "John Doe",
                Age = 30
            };

            // Act
            customer.UpdatePhoneNumber(PhoneNumber);

            // Assert
            customer.PhoneNumber.Should().Be(PhoneNumber);
        }

        [Fact]
        public void UpdateWebsite_InvalidWebsite_InvalidCustomerOperationExceptionThrown()
        {
            // Arrange
            const string Website = "example";
            var customer = new Customer
            {
                Id = Guid.Parse("A2292AE9-C00E-4402-A4A0-CDE6D33EA8F1"),
                Name = "John Doe",
                Age = 30
            };

            // Act
            Action act = () => customer.UpdateWebsite(Website);

            // Assert
            act.Should().ThrowExactly<InvalidCustomerOperationException>();
        }

        [Fact]
        public void UpdatePhoneNumber_InvalidPhoneNumber_InvalidCustomerOperationExceptionThrown()
        {
            // Arrange
            const int PhoneNumber = 0;
            var customer = new Customer
            {
                Id = Guid.Parse("A2292AE9-C00E-4402-A4A0-CDE6D33EA8F1"),
                Name = "John Doe",
                Age = 30
            };

            // Act
            Action act = () => customer.UpdatePhoneNumber(PhoneNumber);

            // Assert
            act.Should().ThrowExactly<InvalidCustomerOperationException>();
        }
    }
}
