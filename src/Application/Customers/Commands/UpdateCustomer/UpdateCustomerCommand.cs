namespace CleanArchitecture.Application.Customers.Commands.UpdateCustomer
{
    using System;
    using MediatR;

    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }

        public long? PhoneNumber { get; set; }

        public string Website { get; set; }
    }
}
