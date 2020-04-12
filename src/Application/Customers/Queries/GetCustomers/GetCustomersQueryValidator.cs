namespace CleanArchitecture.Application.Customers.Queries.GetCustomers
{
    using System;
    using FluentValidation;

    public class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
    {
        public GetCustomersQueryValidator()
        {
            this.RuleForEach(q => q.Ids)
                .NotEmpty();

            this.RuleForEach(q => q.Ages)
                .GreaterThan(0);

            this.RuleForEach(q => q.PhoneNumbers)
                .GreaterThan(0);

            this.RuleForEach(q => q.Websites)
                .Must(ValidUri);
        }

        private static bool ValidUri(string url)
        {
            return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _);
        }
    }
}
