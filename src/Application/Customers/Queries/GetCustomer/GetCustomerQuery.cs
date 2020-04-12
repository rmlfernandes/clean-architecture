namespace CleanArchitecture.Application.Customers.Queries.GetCustomer
{
    using System;
    using MediatR;

    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
