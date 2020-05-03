namespace CleanArchitecture.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Application.Customers.Queries.GetCustomers;
    using CleanArchitecture.Domain.Entities;

    public class InMemoryCustomersRepository : ICustomersRepository
    {
        private readonly Dictionary<Guid, Customer> customers;

        public InMemoryCustomersRepository()
        {
            this.customers = new Dictionary<Guid, Customer>();
        }

        public Task<Guid> CreateCustomerAsync(Customer customer)
        {
            this.customers
                .Add(customer.Id, customer);

            return Task.FromResult(customer.Id);
        }

        public Task DeleteCustomerAsync(Guid id)
        {
            this.customers
                .Remove(id);

            return Task.CompletedTask;
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            var customer = this.customers
                .GetValueOrDefault(id);

            return Task.FromResult(customer);
        }

        public Task<List<Customer>> GetCustomersAsync(GetCustomersQuery query)
        {
            var customers = this.customers
                .Where(c => BuildGetCustomersFilter(c, query))
                .Select(c => c.Value)
                .ToList();

            return Task.FromResult(customers);
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            this.customers
                .Remove(customer.Id);

            this.customers
                .Add(customer.Id, customer);

            return Task.CompletedTask;
        }

        private static bool BuildGetCustomersFilter(KeyValuePair<Guid, Customer> customer, GetCustomersQuery query)
        {
            var result = true;

            if (query.Ids.Any())
            {
                result &= query.Ids.Contains(customer.Value.Id);
            }

            if (query.Names.Any())
            {
                result &= query.Names.Contains(customer.Value.Name);
            }

            if (query.Ages.Any())
            {
                result &= query.Ages.Contains(customer.Value.Age);
            }

            if (query.PhoneNumbers.Any())
            {
                result &= query.PhoneNumbers.Any(phoneNumber => phoneNumber == customer.Value.PhoneNumber);
            }

            if (query.Websites.Any())
            {
                result &= query.Websites.Any(website => website == customer.Value.Website?.ToString());
            }

            return result;
        }
    }
}
