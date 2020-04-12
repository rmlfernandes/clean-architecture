namespace CleanArchitecture.Application.Customers.Queries.GetCustomers
{
    using System;
    using System.Collections.Generic;
    using MediatR;

    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
        public GetCustomersQuery()
        {
            this.Ids = new List<Guid>();
            this.Names = new List<string>();
            this.Ages = new List<int>();
            this.PhoneNumbers = new List<long>();
            this.Websites = new List<string>();
        }

        public GetCustomersQuery(
            List<Guid> ids,
            List<string> names,
            List<int> ages,
            List<long> phoneNumbers,
            List<string> websites)
        {
            this.Ids = ids ?? new List<Guid>();
            this.Names = names ?? new List<string>();
            this.Ages = ages ?? new List<int>();
            this.PhoneNumbers = phoneNumbers ?? new List<long>();
            this.Websites = websites ?? new List<string>();
        }

        public List<Guid> Ids { get; }

        public List<string> Names { get; }

        public List<int> Ages { get; }

        public List<long> PhoneNumbers { get; }

        public List<string> Websites { get; }
    }
}
