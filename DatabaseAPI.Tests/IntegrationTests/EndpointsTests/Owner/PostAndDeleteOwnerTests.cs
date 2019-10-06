using DatabaseAPI.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Owner
{
    public class PostAndDeleteOwnerTests : AbstractEndpointTests
    {
        public PostAndDeleteOwnerTests(
            WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task PostOwnerAsync_Returns200OKOnRequest()
        {
            OwnerDTO originalDto = GetDTOWithName("Test for 200 OK status code");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, originalDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string deletionUrl = OWNERS_ROOT_URL + createdDto.Id;
            await RequestDeleteAsync(deletionUrl);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task PostOwnerAsync_ReturnsOwnerWithIdOtherThanZero()
        {
            OwnerDTO originalDto = GetDTOWithName("Test for id value");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, originalDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string deletionUrl = OWNERS_ROOT_URL + createdDto.Id;
            await RequestDeleteAsync(deletionUrl);
            Assert.True(createdDto.Id != 0);
        }

        [Fact]
        public async Task PostOwnerAsyncWithoutName_Returns401BadRequest()
        {
            OwnerDTO dto = new OwnerDTO();
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, dto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string deletionUrl = OWNERS_ROOT_URL + createdDto.Id;
            await RequestDeleteAsync(deletionUrl);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostOwnerAsync_GetsTheSameNameAfterPost()
        {
            OwnerDTO originalDto = GetDTOWithName("Name comparison");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, originalDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id;
            var getResponse = await RequestGetAsync(entityUrl);
            OwnerDTO getDto = await DeserialiseAsync<OwnerDTO>(getResponse);
            await RequestDeleteAsync(entityUrl);
            Assert.Equal(originalDto.Name, getDto.Name);
        }

        [Fact]
        public async Task DeleteOwnerAsync_Returns204NoRequest()
        {
            OwnerDTO originalDto = GetDTOWithName("Test for 204 on deletion");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, originalDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id;
            var deleteResponse = await RequestDeleteAsync(entityUrl);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteNonExistingOwnerAsync_Returns404NotFound()
        {
            string deletionUrl = OWNERS_ROOT_URL + "123456789";
            var deleteResponse = await RequestDeleteAsync(deletionUrl);
            Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteOwnerAsync_Returns404NotFoundOnGetAfterDeleting()
        {
            OwnerDTO originalDto = GetDTOWithName("Test for 404 on getting the deleted");
            var response = await RequestPostAsync<OwnerDTO>(OWNERS_ROOT_URL, originalDto);
            var createdDto = await DeserialiseAsync<OwnerDTO>(response);
            string entityUrl = OWNERS_ROOT_URL + createdDto.Id;
            await RequestDeleteAsync(entityUrl);
            var getResponse = await RequestGetAsync(entityUrl);
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        private static OwnerDTO GetDTOWithName(string name)
        {
            return new OwnerDTO
                .Builder()
                .WithName(name)
                .Build();
        }
    }
}
