using DatabaseAPI.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Owner
{
    public class GetSingleOwnerTests : AbstractEndpointTests
    {
        private string OWNERS_ROOT_URL = "/database-api/owners/";

        public GetSingleOwnerTests(WebApplicationFactory<Startup> injectedFactory) : base(injectedFactory)
        {
        }

        [Theory]
        [InlineData(15)]
        [InlineData(3)]
        public async Task GetExistingOwner_Returns200Async(int id)
        {
            string url = OWNERS_ROOT_URL + id.ToString();
            var response = await RequestGetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(987654321)]
        [InlineData(-3000)]
        public async Task GetNonExistingOwner_Returns404(int id)
        {
            string url = OWNERS_ROOT_URL + id.ToString();
            var response = await RequestGetAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData(18, "Ermewa - Sati")]
        [InlineData(12, "STK")]
        public async Task GetExistingOwner_ReturnsSpecificNames(
            int id, 
            string expectedName)
        {
            string url = OWNERS_ROOT_URL + id.ToString();
            var response = await RequestGetAsync(url);
            OwnerDTO dto = await DeserialiseAsync<OwnerDTO>(response);
            Assert.Equal(expectedName, dto.Name);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public async Task GetExistingOwner_ReturnsTheSameId(int id)
        {
            string url = OWNERS_ROOT_URL + id.ToString();
            var response = await RequestGetAsync(url);
            OwnerDTO dto = await DeserialiseAsync<OwnerDTO>(response);
            Assert.Equal(id, dto.Id);
        }
    }
}
