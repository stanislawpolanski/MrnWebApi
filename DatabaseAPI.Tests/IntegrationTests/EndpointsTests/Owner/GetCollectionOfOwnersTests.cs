using DatabaseAPI.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Owner
{
    public class GetCollectionOfOwnersTests : AbstractEndpointTests
    {
        public GetCollectionOfOwnersTests(WebApplicationFactory<Startup> injectedFactory) : base(injectedFactory)
        {
        }

        [Fact]
        public async Task GetAllOwners_ReturnsStatus200OK()
        {
            var response = await RequestGetAsync(OWNERS_ROOT_URL);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllOwners_AllDtosHaveAprropriateUrl()
        {
            var response = await RequestGetAsync(OWNERS_ROOT_URL);
            IEnumerable<OwnerDTO> owners = 
                await DeserialiseAsync<IEnumerable<OwnerDTO>>(response);

            foreach(OwnerDTO owner in owners)
            {
                string expectedUrl = OWNERS_ROOT_URL + owner.Id;
                Assert.Equal(expectedUrl, owner.Url);
            }
        }

        [Fact]
        public async Task GetAllOwners_AllDtosHaveNames()
        {
            var response = await RequestGetAsync(OWNERS_ROOT_URL);
            IEnumerable<OwnerDTO> owners =
                await DeserialiseAsync<IEnumerable<OwnerDTO>>(response);

            foreach (OwnerDTO owner in owners)
            {
                Assert.False(string.IsNullOrEmpty(owner.Name));
            }
        }

        [Fact]
        public async Task GetAllOwners_ReturnsAtLeastTenOwners()
        {
            var response = await RequestGetAsync(OWNERS_ROOT_URL);
            IEnumerable<OwnerDTO> owners =
                await DeserialiseAsync<IEnumerable<OwnerDTO>>(response);
            Assert.True(owners.ToList().Count > 10);
        }

        [Theory]
        [InlineData(1, "PKP PLK")]
        [InlineData(17, "Transchem Włocławek")]
        public async Task GetAllOwners_ContainsSpecificOwner(
            int id, 
            string name)
        {
            var response = await RequestGetAsync(OWNERS_ROOT_URL);
            IEnumerable<OwnerDTO> owners =
                await DeserialiseAsync<IEnumerable<OwnerDTO>>(response);
            OwnerDTO owner = owners
                .ToList()
                .Where(dto => dto.Id == id)
                .FirstOrDefault();
            Assert.Equal(name, owner.Name);
        }
    }
}
