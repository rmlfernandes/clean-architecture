namespace CleanArchitecture.Application.Customers.Queries.GetCustomers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using MediatR;

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository repository;

        public GetCustomersQueryHandler(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            var customers = await this.repository
                .GetCustomersAsync(query);

            return customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    PhoneNumber = c.PhoneNumber,
                    Website = c.Website?.ToString(),
                    Created = c.Created,
                    CreatedBy = c.CreatedBy,
                    LastModified = c.LastModified,
                    LastModifiedBy = c.LastModifiedBy
                })
                .ToList();
        }
    }
}
