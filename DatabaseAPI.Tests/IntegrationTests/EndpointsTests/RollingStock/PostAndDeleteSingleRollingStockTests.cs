using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class PostAndDeleteSingleRollingStockTests : AbstractEndpointTests
    {
        private readonly string ROLLING_STOCK_ROOT_PATH = "/database-api/rolling-stock";

        public PostAndDeleteSingleRollingStockTests(
            WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Rolling stock test #2", 5)]
        public async Task PostsRollingStockWithNameAndOwnerId(string url,
            string name,
            int ownerId)
        {
            RollingStockDTO inputDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();

            var response = await RequestPostAsync<RollingStockDTO>(url, inputDto);
            RollingStockDTO outputDto = await DeserialiseAsync<RollingStockDTO>(response);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(name, outputDto.Name);
            Assert.Equal(ownerId, outputDto.Owner.Id);

            string deletionUrl = UriRoute
                .GetRouteFromNodes(url, outputDto.Id.ToString())
                .ToString();
            await RequestDeleteAsync(deletionUrl);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", 5)]
        public async Task PostsRollingStockWithNoName_ReturnsBadRequest(
            string url,
            int ownerId)
        {
            RollingStockDTO inputDto = new RollingStockDTO
                .Builder()
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();

            var response = await RequestPostAsync<RollingStockDTO>(url, inputDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Name: PostsRollingStockWithNoOwner")]
        public async Task PostsRollingStockWithNoOwner_ReturnsBadRequest(
            string url,
            string name)
        {
            RollingStockDTO inputDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .Build();

            var response = await RequestPostAsync<RollingStockDTO>(url, inputDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Name: DeletesRollingStock", 9)]
        public async Task DeletesRollingStock(string url, string name, int ownerId)
        {
            RollingStockDTO inDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();

            HttpResponseMessage postResponse = await RequestPostAsync(url, inDto);
            RollingStockDTO outDto = await base.DeserialiseAsync<RollingStockDTO>(postResponse);

            string deletionUrl = UriRoute.GetRouteStringFromNodes(
                ROLLING_STOCK_ROOT_PATH,
                outDto.Id.ToString());

            HttpResponseMessage deletionResponse = await base.RequestDeleteAsync(deletionUrl);
            Assert.Equal(HttpStatusCode.OK, deletionResponse.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/123456789")]
        public async Task DeletesNotExistingRollingStock_Returns404(string url)
        {
            HttpResponseMessage deletionResponse = await base.RequestDeleteAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, deletionResponse.StatusCode);
        }
    }
}
