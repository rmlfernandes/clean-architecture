using System;
using FluentValidation;

namespace CleanArchitecture.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            this.RuleFor(c => c.Id)
                .NotEmpty();

            this.RuleFor(c => c.PhoneNumber)
                .GreaterThan(0)
                .When(c => c.PhoneNumber != null);

            this.RuleFor(c => c.Website)
                .Must(ValidUri)
                .When(c => !string.IsNullOrEmpty(c.Website));
        }

        private static bool ValidUri(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
