namespace CleanArchitecture.Infrastructure.UnitTests
{
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using CleanArchitecture.Infrastructure.Services;
    using FluentAssertions;
    using Xunit;

    public class IdentityServiceTests
    {
        private readonly IIdentityService identityService;

        public IdentityServiceTests()
        {
            this.identityService = new IdentityService();
        }

        [Fact]
        public async Task GetUserIdentifierAsync_ValidRequest_UserIdentifierReturned()
        {
            // Act
            var identifier = await this.identityService.GetUserIdentifierAsync();

            // Assert
            identifier.Should().NotBeEmpty();
        }
    }
}
