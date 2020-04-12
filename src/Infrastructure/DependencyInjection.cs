namespace CleanArchitecture.Infrastructure
{
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Infrastructure.Repositories;
    using CleanArchitecture.Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, InMemoryCustomersRepository>();
            services.AddSingleton<IIdentityService, IdentityService>();

            return services;
        }
    }
}
