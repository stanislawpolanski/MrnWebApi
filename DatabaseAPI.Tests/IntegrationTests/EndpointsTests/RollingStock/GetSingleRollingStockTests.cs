using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class GetSingleRollingStockTests : AbstractEndpointTests
    {
        public GetSingleRollingStockTests(
            WebApplicationFactory<Startup> injectedFactory) : 
            base(injectedFactory)
        {
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/6")]
        public async Task Returns200OnExisting(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/987654321")]
        public async Task Returns404OnNonExisting(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Theory]
        [InlineData("/database-api/rolling-stock/6")]
        public async Task Returns404OnExistingButStation(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/8", "ET22")]
        public async Task GetSpecifiedRollingStockWithName(
            string url, 
            string expectedName)
        {
            RollingStockDTO result = await GetRollingStockDTOByUrl(url);
            Assert.Equal(expectedName, result.Name);
        }



        [Theory]
        [InlineData("/database-api/rolling-stock/8", "PKP PLK")]
        public async Task GetSpecifiedRollingStockWithOwner(
            string url, 
            string expectedOwnerName)
        {
            var result = await GetRollingStockDTOByUrl(url);
            Assert.Equal(expectedOwnerName, result.Owner.Name);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock/8")]
        public async Task GetSpecifiedRollingStockWithPhotos(string url)
        {
            var result = await GetRollingStockDTOByUrl(url);
            Assert.NotEmpty(result.Photos);
        }

        private async Task<RollingStockDTO> GetRollingStockDTOByUrl(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            RollingStockDTO result = await
                DeserialiseFromGetResponseAsync<RollingStockDTO>(response);
            return result;
        }
    }
}
