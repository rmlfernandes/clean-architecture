namespace CleanArchitecture.Application.Customers.Commands.DeleteCustomer
{
    using System;
    using MediatR;

    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
