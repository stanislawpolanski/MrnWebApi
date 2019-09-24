using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
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
        [InlineData("Put - changing owner id test", 5, 2)]
        public async Task PutsWithChangedOwnerId_Comparison(
            string name,
            int originalOwnerId,
            int updatedOwnerId)
        {
            RollingStockDTO originalPostedDTO = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(originalOwnerId).Build())
                .Build();
            var postOriginalResponse = await PostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                originalPostedDTO);
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            RollingStockDTO updatedPostedDTO = new RollingStockDTO
                .Builder()
                .WithId(rollingStockEntityId)
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(updatedOwnerId).Build())
                .Build();
            await base.PutAsync<RollingStockDTO>(
                GetUrlWithId(rollingStockEntityId), updatedPostedDTO);
            var getUpdatedResponse = await base
                .GetAsync(GetUrlWithId(rollingStockEntityId));
            RollingStockDTO changedDto = await base
                .DeserialiseAsync<RollingStockDTO>(getUpdatedResponse);
            int actualOwnerId = changedDto.Owner.Id;
            Assert.Equal(updatedOwnerId, actualOwnerId);
            await base.DeleteAsync(GetUrlWithId(rollingStockEntityId));
        }

        [Theory]
        [InlineData("Put - original name (invalid)", "Put - updated name - OK", 5)]
        public async Task PutsWithChangedName_Comparison(
            string originalName,
            string updatedExpectedName,
            int ownerId)
        {
            RollingStockDTO originalPostedDTO = new RollingStockDTO
                .Builder()
                .WithName(originalName)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var postOriginalResponse = await PostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                originalPostedDTO);
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            RollingStockDTO updatedPostedDTO = new RollingStockDTO
                .Builder()
                .WithId(rollingStockEntityId)
                .WithName(updatedExpectedName)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            await base.PutAsync<RollingStockDTO>(
                GetUrlWithId(rollingStockEntityId), updatedPostedDTO);
            var getUpdatedResponse = await base
                .GetAsync(GetUrlWithId(rollingStockEntityId));
            RollingStockDTO changedDto = await base
                .DeserialiseAsync<RollingStockDTO>(getUpdatedResponse);
            string actualName = changedDto.Name;
            Assert.Equal(updatedExpectedName, actualName);
            await base.DeleteAsync(GetUrlWithId(rollingStockEntityId));
        }


        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoName_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            RollingStockDTO originalPostedDTO = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var postOriginalResponse = await PostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                originalPostedDTO);
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            RollingStockDTO updatedDto = new RollingStockDTO
                .Builder()
                .WithId(rollingStockEntityId)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var response = await base.PutAsync<RollingStockDTO>(
                GetUrlWithId(rollingStockEntityId), updatedDto);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await base.DeleteAsync(GetUrlWithId(rollingStockEntityId));
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoId_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            RollingStockDTO originalPostedDTO = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var postOriginalResponse = await PostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                originalPostedDTO);
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            RollingStockDTO updatedDto = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var response = await base.PutAsync<RollingStockDTO>(
                GetUrlWithId(rollingStockEntityId), updatedDto);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await base.DeleteAsync(GetUrlWithId(rollingStockEntityId));
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task PutsRollingStockWithNoOwnerId_ReturnsBadRequest(string url)
        {
            string name = "Sample name";
            int ownerId = 5;
            RollingStockDTO originalPostedDTO = new RollingStockDTO
                .Builder()
                .WithName(name)
                .WithOwner(new OwnerDTO.Builder().WithId(ownerId).Build())
                .Build();
            var postOriginalResponse = await PostAsync<RollingStockDTO>(
                PUT_ROLLING_STOCK_ROOT,
                originalPostedDTO);
            var retrievedPostedDTO =
                await DeserialiseAsync<RollingStockDTO>(postOriginalResponse);
            int rollingStockEntityId = retrievedPostedDTO.Id;
            RollingStockDTO updatedDto = new RollingStockDTO
                .Builder()
                .WithId(rollingStockEntityId)
                .WithName(name)
                .Build();
            var response = await base.PutAsync<RollingStockDTO>(
                GetUrlWithId(rollingStockEntityId), updatedDto);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await base.DeleteAsync(GetUrlWithId(rollingStockEntityId));
        }

        private string GetUrlWithId(int id)
        {
            return PUT_ROLLING_STOCK_ROOT + id.ToString();
        }
    }
}
