namespace CleanArchitecture.Application.Customers.Commands.UpdateCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using MediatR;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomersRepository repository;
        private readonly IIdentityService identityService;

        public UpdateCustomerCommandHandler(
            ICustomersRepository repository,
            IIdentityService identityService)
        {
            this.repository = repository;
            this.identityService = identityService;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await this.repository.GetCustomerAsync(command.Id);

            if (command.PhoneNumber.HasValue)
            {
                customer.UpdatePhoneNumber(command.PhoneNumber.Value);
            }

            if (!string.IsNullOrWhiteSpace(command.Website))
            {
                customer.UpdateWebsite(command.Website);
            }

            customer.LastModified = DateTime.UtcNow;
            customer.LastModifiedBy = (await this.identityService.GetUserIdentifierAsync()).ToString();

            await this.repository.UpdateCustomerAsync(customer);

            return Unit.Value;
        }
    }
}
