namespace CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Domain.Entities;
    using MediatR;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository repository;
        private readonly IIdentityService identityService;

        public CreateCustomerCommandHandler(
            ICustomerRepository repository,
            IIdentityService identityService)
        {
            this.repository = repository;
            this.identityService = identityService;
        }

        public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Age = command.Age,
                PhoneNumber = command.PhoneNumber,
                Website = string.IsNullOrEmpty(command.Website) ? null : new Uri(command.Website),
                Created = DateTime.UtcNow,
                CreatedBy = (await this.identityService.GetUserIdentifierAsync()).ToString(),
            };

            return await this.repository
                .CreateCustomerAsync(customer);
        }
    }
}
