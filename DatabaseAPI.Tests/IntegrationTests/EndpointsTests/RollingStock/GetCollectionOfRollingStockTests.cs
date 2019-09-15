using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class GetCollectionOfRollingStockTests : AbstractEndpointTests
    {
        public GetCollectionOfRollingStockTests(
            WebApplicationFactory<Startup> injectedFactory) : 
            base(injectedFactory)
        {
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task Returns200(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "/database-api/station")]
        public async Task CollectionDoesNotContainStations(
            string rollingStockUrl, 
            string stationsUrl)
        {
            var trains = await GetCollectionByUrl(rollingStockUrl);
            var stationResponse = await GetGetResponseAsync(stationsUrl);
            List<StationDTO> stations = 
                await DeserialiseFromGetResponseAsync<List<StationDTO>>(stationResponse);
            ISet<int> trainIds = 
                trains
                .Select(train => train.Id)
                .ToHashSet();
            stations.ForEach(station => Assert.False(trainIds.Contains(station.Id)));
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", "ET22")]
        public async Task ReturnsSpecifiedNames(string url, string expectedName)
        {
            var collection = await GetCollectionByUrl(url);
            Assert.Contains<RollingStockDTO>(
                collection, 
                dto => dto.Name.Equals(expectedName));
        }

        [Theory]
        [InlineData("/database-api/rolling-stock", 8, "PKP Cargo")]
        public async Task SpecifiedIdsHaveSpecifiedOwners(
            string url,
            int id,
            string ownerName)
        {
            var collection = await GetCollectionByUrl(url);
            Assert.Contains<RollingStockDTO>(
                collection,
                dto => dto.Id.Equals(id) && dto.Owner.Name.Equals(ownerName));
        }

        [Theory]
        [InlineData("/database-api/rolling-stock")]
        public async Task UrlOfEachObjectContainsItsId(string url)
        {
            var collection = await GetCollectionByUrl(url);
            Action<RollingStockDTO> urlFitsThePatternAndContainsId = dto => 
                dto.Url.Equals("/database-api/rolling-stock/" + dto.Id.ToString());
            Assert.All<RollingStockDTO>(
                collection,
                urlFitsThePatternAndContainsId);
        }

        private async Task<IEnumerable<RollingStockDTO>> GetCollectionByUrl(string url)
        {
            var response = await GetGetResponseAsync(url);
            var collection = await DeserialiseFromGetResponseAsync<
                IEnumerable<RollingStockDTO>>(response);
            return collection;
        }
    }
}
