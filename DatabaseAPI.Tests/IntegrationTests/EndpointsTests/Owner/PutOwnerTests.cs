using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
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
            string url = OWNERS_ROOT_URL + id;
            var response = await PutResponse(url, id, name);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PutOwnerAsync_PutsDtoWithIdDifferentThanUrl_ReturnsBadRequest()
        {
            OwnerDTO createdDto = await PostInitialDto(0, "Test bad request - initial");
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id.ToString();
            try
            {
                int id = 123456789;
                string name = "Test bad request - changed";
                var putResponse = await PutResponse(entityUrl, id, name);
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
            OwnerDTO createdDto = await PostInitialDto(0, "Test for 204 on put correct owner - initial");
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id.ToString();
            try
            {
                string name = "Test for 204 on put correct owner - updated";
                var putResponse = await PutResponse(entityUrl, createdDto.Id, name);
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
            OwnerDTO createdInitialDto = await PostInitialDto(0, "Test for 204 on put correct owner - initial");
            int id = createdInitialDto.Id;
            string url = OWNERS_ROOT_URL + id.ToString();
            try
            {
                var putResponse = await PutResponse(url, id, expectedName);
                var getResponse = await RequestGetAsync(url);
                var retrievedDto = await DeserialiseAsync<OwnerDTO>(getResponse);
                string actualName = retrievedDto.Name;
                Assert.Equal(expectedName, actualName);
            }
            finally
            {
                await RequestDeleteAsync(url);
            }
        }

        private async Task<OwnerDTO> PostInitialDto(int id, string name)
        {
            var initialPostResponse = await RequestPostAsync<OwnerDTO>(
                OWNERS_ROOT_URL,
                ProduceFullDTO(id, name));
            var createdDto = await DeserialiseAsync<OwnerDTO>(initialPostResponse);
            return createdDto;
        }

        private static OwnerDTO ProduceFullDTO(int id, string name)
        {
            return new OwnerDTO
                .Builder()
                .WithId(id)
                .WithName(name)
                .Build();
        }


        private async Task<HttpResponseMessage> PutResponse(string entityUrl, int id, string name)
        {
            OwnerDTO changedDTO = ProduceFullDTO(id, name);
            var putResponse = await RequestPutAsync<OwnerDTO>(entityUrl, changedDTO);
            return putResponse;
        }
    }
}
