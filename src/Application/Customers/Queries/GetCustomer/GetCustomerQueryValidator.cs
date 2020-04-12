namespace CleanArchitecture.Application.Customers.Queries.GetCustomer
{
    using FluentValidation;

    public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerQueryValidator()
        {
            this.RuleFor(q => q.Id)
                .NotEmpty();
        }
    }
}
