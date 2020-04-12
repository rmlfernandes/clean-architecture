namespace CleanArchitecture.Application
{
    using System.Reflection;
    using CleanArchitecture.Application.Customers.Commands.CreateCustomer;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();

            return services;
        }
    }
}
