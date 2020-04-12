namespace CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    using System;
    using MediatR;

    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public long? PhoneNumber { get; set; }

        public string Website { get; set; }
    }
}
