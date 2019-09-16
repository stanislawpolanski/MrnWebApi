using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
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

        protected async Task<T> DeserialiseFromGetResponseAsync<T>(
            HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            T deserialised = JsonConvert.DeserializeObject<T>(content);
            return deserialised;
        }
    }
}
