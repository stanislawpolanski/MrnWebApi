using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Owner
{
    public class PutOwnerTests : AbstractEndpointTests
    {
        public PutOwnerTests(WebApplicationFactory<Startup> injectedFactory)
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task PutOwnerAsync_PutsNonExistingOwner_Returns404()
        {
            string name = "Puts non existing owner";
            int id = 123456789;
            OwnerDTO dto = ProduceFullDTO(id, name);
            string url = OWNERS_ROOT_URL + id;
            var response = await RequestPutAsync<OwnerDTO>(url, dto);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PutOwnerAsync_PutsDtoWithIdDifferentThanUrl_ReturnsBadRequest()
        {
            OwnerDTO initialDTO = ProduceFullDTO(0, "Test bad request - initial");
            var initialPostResponse = await RequestPostAsync<OwnerDTO>(
                OWNERS_ROOT_URL,
                initialDTO);
            var createdDto = await DeserialiseAsync<OwnerDTO>(initialPostResponse);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id.ToString();
            try
            {
                OwnerDTO changedDTO = ProduceFullDTO(123456789, "Test bad request - changed");
                var putResponse = await RequestPutAsync<OwnerDTO>(entityUrl, changedDTO);
                Assert.Equal(HttpStatusCode.BadRequest, putResponse.StatusCode);
            }
            finally
            {
                await RequestDeleteAsync(entityUrl);
            }
        }

        [Fact]
        public async Task PutOwnerAsync_PutsCorrectOwner_Returns204()
        {
            OwnerDTO initialDto = ProduceFullDTO(0, "Test for 204 on put correct owner - initial");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, initialDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id.ToString();
            try
            {
                OwnerDTO updatedDto = ProduceFullDTO(createdDto.Id, "Test for 204 on put correct owner - updated");
                var putResponse = await RequestPutAsync<OwnerDTO>(entityUrl, updatedDto);
                Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);
            }
            finally
            {
                await RequestDeleteAsync(entityUrl);
            }
        }

        [Fact]
        public async Task PutOwnerAsync_PutsCorrectOwnerAndGetsAgain_NameChanged()
        {
            string expectedName = "Test for getting correct owner - updated";
            string initialName = "Test for getting correct owner - initial";
            OwnerDTO initialDto = ProduceFullDTO(0, initialName);
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, initialDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id.ToString();
            try
            {
                OwnerDTO updatedDto = ProduceFullDTO(createdDto.Id, expectedName);
                var putResponse = await RequestPutAsync<OwnerDTO>(entityUrl, updatedDto);
                var getResponse = await RequestGetAsync(entityUrl);
                var retrievedDto = await DeserialiseAsync<OwnerDTO>(getResponse);
                string actualName = retrievedDto.Name;
                Assert.Equal(expectedName, actualName);
            }
            finally
            {
                await RequestDeleteAsync(entityUrl);
            }
        }

        private static OwnerDTO ProduceFullDTO(int id, string name)
        {
            return new OwnerDTO
                .Builder()
                .WithId(id)
                .WithName(name)
                .Build();
        }
    }
}
