using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests
{
    public class AbstractEndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<DatabaseAPI.Startup> factory;

        public AbstractEndpointTests(
            WebApplicationFactory<DatabaseAPI.Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        protected async Task<HttpResponseMessage> GetGetResponseAsync(string url)
        {
            return await factory.CreateClient().GetAsync(url);
        }
    }
}
