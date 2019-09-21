using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.Routing;
using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class ManipulateSingleRollingStockTests : AbstractEndpointTests
    {
        private readonly string ROLLING_STOCK_ROOT_PATH = "/database-api/rolling-stock/";

        public ManipulateSingleRollingStockTests(
            WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Name of post rolling stock", 5)]
        public async Task PostsRollingStockWithNameAndOwnerId(string url, string name, int ownerId)
        {
            RollingStockDTO inputDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();

            var response = await PostAsync<RollingStockDTO>(url, inputDto);
            RollingStockDTO outputDto = 
                await Deserialise<RollingStockDTO>(response);
            
            Assert.Equal(name, outputDto.Name);
            Assert.Equal(ownerId, outputDto.Owner.Id);
            //todo may be splitted into two tests
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            string deletionUrl = UriRoute
                .GetRouteFromNodes(url, outputDto.Id.ToString())
                .ToString();
            await DeleteAsync(deletionUrl);
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

            var response = await PostAsync<RollingStockDTO>(url, inputDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Test name")]
        public async Task PostsRollingStockWithNoOwner_ReturnsBadRequest(
            string url, 
            string name)
        {
            RollingStockDTO inputDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .Build();

            var response = await PostAsync<RollingStockDTO>(url, inputDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "Name of delete rolling stock", 9)]
        public async Task DeletesRollingStock(string url, string name, int ownerId)
        {
            RollingStockDTO inDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();

            HttpResponseMessage postResponse = await PostAsync(url, inDto);
            RollingStockDTO outDto = await base.Deserialise<RollingStockDTO>(postResponse);

            string deletionUrl = UriRoute.GetRouteStringFromNodes(
                ROLLING_STOCK_ROOT_PATH, 
                outDto.Id.ToString());

            HttpResponseMessage deletionResponse = await base.DeleteAsync(deletionUrl);
            Assert.Equal(HttpStatusCode.OK, deletionResponse.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/123456789")]
        public async Task DeletesNotExistingRollingStock_Returns404(string url)
        {
            HttpResponseMessage deletionResponse = await base.DeleteAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, deletionResponse.StatusCode);
        }
    }
}
