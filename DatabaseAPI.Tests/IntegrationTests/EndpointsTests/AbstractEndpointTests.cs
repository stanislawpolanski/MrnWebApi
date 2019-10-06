using DatabaseAPI.DataAccess.Inner.Scaffold;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests
{
    public class AbstractEndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected string OWNERS_ROOT_URL = "/database-api/owner/";

        protected readonly WebApplicationFactory<Startup> factory;

        public AbstractEndpointTests(
            WebApplicationFactory<DatabaseAPI.Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        protected async Task<HttpResponseMessage> RequestGetAsync(string url)
        {
            return await factory.CreateClient().GetAsync(url);
        }

        protected async Task<T> DeserialiseAsync<T>(
            HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            T deserialised = JsonConvert.DeserializeObject<T>(content);
            return deserialised;
        }

        protected async Task<HttpResponseMessage> RequestPostAsync<T>(
            string url, 
            T body)
        {
            return await factory.CreateClient().PostAsJsonAsync<T>(url, body);
        }

        protected async Task<HttpResponseMessage> RequestPutAsync<T>(string url, T body)
        {
            return await factory.CreateClient().PutAsJsonAsync<T>(url, body);
        }

        protected async Task<HttpResponseMessage> RequestDeleteAsync(string url)
        {
            return await factory.CreateClient().DeleteAsync(url);
        }
    }
}
