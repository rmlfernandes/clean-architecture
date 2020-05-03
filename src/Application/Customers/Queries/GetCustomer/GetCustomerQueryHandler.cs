namespace CleanArchitecture.Application.Customers.Queries.GetCustomer
{
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Exceptions;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Domain.Entities;
    using MediatR;

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomersRepository repository;

        public GetCustomerQueryHandler(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = await this.repository.GetCustomerAsync(query.Id);

            if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), query.Id.ToString());
            }

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                PhoneNumber = customer.PhoneNumber,
                Website = customer.Website?.ToString(),
                Created = customer.Created,
                CreatedBy = customer.CreatedBy,
                LastModified = customer.LastModified,
                LastModifiedBy = customer.LastModifiedBy
            };
        }
    }
}
