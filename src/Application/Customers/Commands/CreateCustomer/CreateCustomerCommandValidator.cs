namespace CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    using System;
    using FluentValidation;

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            this.RuleFor(c => c.Name)
                .NotEmpty();

            this.RuleFor(c => c.Age)
                .GreaterThan(0);

            this.RuleFor(c => c.PhoneNumber)
                .GreaterThan(0)
                .When(c => c.PhoneNumber != null);

            this.RuleFor(c => c.Website)
                .Must(ValidUri)
                .When(c => !string.IsNullOrEmpty(c.Website));
        }

        private static bool ValidUri(string url)
        {
            return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var result);
        }
    }
}
