using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class PutSingleRollingStockTests : AbstractEndpointTests
    {
        private string PUT_ROLLING_STOCK_ROOT = "/database-api/rolling-stock/";

        public PutSingleRollingStockTests(
            WebApplicationFactory<Startup> injectedFactory)
            : base(injectedFactory)
        {
        }

        [Theory]
        [InlineData("Put - original name (invalid)", "Put - updated name - OK", 5)]
        public async Task PutsWithChangedName_Returns204NoResponse(
            string originalName,
            string updatedExpectedName,
            int ownerId)
        {
            int rollingStockEntityId =
                await PostOriginalRollingStock(originalName, ownerId);
            try
            {
                var updatedPostedDTO = GetOriginalDTO(updatedExpectedName, ownerId);
                updatedPostedDTO.Id = rollingStockEntityId;
                var response = await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(rollingStockEntityId), updatedPostedDTO);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(rollingStockEntityId));
            }
        }


        [Theory]
        [InlineData("Put - change id", "Put - change id", 9, 18)]
        [InlineData("Put - change name - ERROR", "Put - change name - OK", 5, 5)]
        [InlineData("Put - change both - ERROR", "Put - change both - OK", 6, 13)]
        public async Task PutsWithChangedData_Comparison(
            string originalName,
            string updatedName,
            int originalOwnerId,
            int updatedOwnerId)
        {
            int postedEntityId =
                await PostOriginalRollingStock(originalName, originalOwnerId);
            try
            {
                RollingStockDTO updatedDto = GetOriginalDTO(updatedName, updatedOwnerId);
                updatedDto.Id = postedEntityId;
                await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(postedEntityId), updatedDto);
                var getUpdatedResponse = await base
                    .RequestGetAsync(GetUrlWithId(postedEntityId));
                RollingStockDTO changedDto = await base
                    .DeserialiseAsync<RollingStockDTO>(getUpdatedResponse);
                int actualOwnerId = changedDto.Owner.Id;
                Assert.Equal(updatedOwnerId, actualOwnerId);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(postedEntityId));
            }
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoName_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            int rollingStockEntityId = await PostOriginalRollingStock(name, ownerId);
            try
            {
                RollingStockDTO updatedDto = new RollingStockDTO
                    .Builder()
                    .WithId(rollingStockEntityId)
                    .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                    .Build();
                var response = await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(rollingStockEntityId), updatedDto);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(rollingStockEntityId));
            }
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoId_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            int rollingStockEntityId = await PostOriginalRollingStock(name, ownerId);
            try
            {
                RollingStockDTO updatedDto = new RollingStockDTO
                    .Builder()
                    .WithName(name)
                    .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                    .Build();
                var response = await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(rollingStockEntityId), updatedDto);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(rollingStockEntityId));
            }
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoOwnerId_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            int rollingStockEntityId = await PostOriginalRollingStock(name, ownerId);
            try
            {
                RollingStockDTO updatedDto = new RollingStockDTO
                    .Builder()
                    .WithId(rollingStockEntityId)
                    .WithName(name)
                    .Build();
                var response = await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(rollingStockEntityId), updatedDto);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(rollingStockEntityId));
            }
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithUrlIdDifferentThanBodyId_ReturnsBadRequest(
            string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            int rollingStockEntityId = await PostOriginalRollingStock(name, ownerId);
            int changedId = rollingStockEntityId + 1;
            try
            {
                RollingStockDTO updatedDto = new RollingStockDTO
                    .Builder()
                    .WithId(changedId)
                    .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                    .Build();
                var response = await base.RequestPutAsync<RollingStockDTO>(
                    GetUrlWithId(rollingStockEntityId), updatedDto);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            finally
            {
                await base.RequestDeleteAsync(GetUrlWithId(rollingStockEntityId));
            }
        }

        private async Task<int> PostOriginalRollingStock(string name, int ownerId)
        {
            var postOriginalResponse = await RequestPostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                GetOriginalDTO(name, ownerId));
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            return rollingStockEntityId;
        }

        private static RollingStockDTO GetOriginalDTO(string name, int ownerId)
        {
            return new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
        }

        private string GetUrlWithId(int id)
        {
            return PUT_ROLLING_STOCK_ROOT + id.ToString();
        }
    }
}
