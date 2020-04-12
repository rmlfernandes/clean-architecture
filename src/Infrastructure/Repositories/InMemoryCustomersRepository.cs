namespace CleanArchitecture.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Domain.Entities;

    public class InMemoryCustomersRepository : ICustomerRepository
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

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers = this.customers
                .Select(c => c.Value);

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
    }
}
