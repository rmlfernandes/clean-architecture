namespace CleanArchitecture.Application.Common.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<Guid> GetUserIdentifierAsync();
    }
}
