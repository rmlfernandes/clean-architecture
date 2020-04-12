namespace CleanArchitecture.Application.Customers.Commands.DeleteCustomer
{
    using FluentValidation;

    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            this.RuleFor(c => c.Id)
                .NotEmpty();
        }
    }
}
