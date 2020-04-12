namespace CleanArchitecture.Application.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanArchitecture.Domain.Entities;

    public interface ICustomerRepository
    {
        Task<Guid> CreateCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(Guid id);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(Guid id);

        Task UpdateCustomerAsync(Customer customer);
    }
}
