namespace CleanArchitecture.Infrastructure.Services
{
    using System;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;

    public class IdentityService : IIdentityService
    {
        public Task<Guid> GetUserIdentifierAsync()
        {
            var identifier = Guid.NewGuid();

            return Task.FromResult(identifier);
        }
    }
}
