using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Station
{
    public class GetCollectionOfStationsTests : AbstractEndpointTests
    {
        private string byRailwayIdPath = "railway/";

        public GetCollectionOfStationsTests(
            WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task GetAllStations_ReturnsAtLeastExpectedNumberOfStations()
        {
            int expectedNumberOfStations = 200;

            var response = await RequestGetAsync(STATION_ROOT_URL);
            var models = await DeserialiseAsync<List<StationDTO>>(response);

            Assert.True(models.Count >= expectedNumberOfStations);
        }

        [Fact]
        public async Task GetAllStations_AllStationsContainsExpectedUrl()
        {
            var response = await RequestGetAsync(STATION_ROOT_URL);
            var models = await DeserialiseAsync<List<StationDTO>>(response);
            foreach(var model in models)
            {
                string expected = STATION_ROOT_URL + model.Id.ToString();
                string actual = model.Url;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async Task GetAllStations_EveryStationsNameIsNotShorterThanMinimal()
        {
            int minimalNameLength = 3;

            var response = await RequestGetAsync(STATION_ROOT_URL);
            var models = await DeserialiseAsync<List<StationDTO>>(response);
            foreach(var model in models)
            {
                int actualNameLenght = model.Name.Length;
                Assert.True(actualNameLenght >= minimalNameLength);
            }
        }

        [Theory]
        [InlineData(78, "Trzebinia")]
        [InlineData(10112, "Łęg Tarnowski")]
        public async Task
            GetAllStations_ContainsSpecificStation(int id, string name)
        {
            var response = await RequestGetAsync(STATION_ROOT_URL);
            var models = await DeserialiseAsync<List<StationDTO>>(response);
            Predicate<StationDTO> containsSpecificStation = 
                station 
                =>
                station.Id.Equals(id) && station.Name.Equals(name);
            Assert.Contains(models, containsSpecificStation);
        }

        [Theory]
        [InlineData(23)]
        [InlineData(10940)]
        [InlineData(10105)]
        public async Task GetStationsByRailwayId_OnExistingRailway_Returns200OK(
            int railwayId)
        {
            HttpResponseMessage response =
                await RequestStationsLocationsByRailwayId(railwayId);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task 
            GetStationsByRailwayId_OnNonExistingRailway_Returns404NotFound()
        {
            int railwayId = 123456789;
            HttpResponseMessage response =
                await RequestStationsLocationsByRailwayId(railwayId);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData(23)]
        [InlineData(10940)]
        public async Task 
            GetStationsByRailwayId_OnExistingRailway_ReturnsNotEmptyCollection(
            int railwayId)
        {
            var models = await ReadStationsOnARaiwayByRailwayId(railwayId);
            Assert.NotEmpty(models);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10625)]
        public async Task
            GetStationsByRailwayId_OnExistingRailway_StationsHasCorrectUrls(
            int railwayId)
        {
            var models = await ReadStationsOnARaiwayByRailwayId(railwayId);
            Assert.All(models, model => {
                string expectedUrl = STATION_ROOT_URL + model.StationId.ToString();
                Assert.Equal(expectedUrl, model.Url); });
        }

        [Theory]
        [InlineData(29, "Przymiarki")]
        [InlineData(3, "Tarnów Mościce")]
        [InlineData(10105, "Powroźnik")]
        public async Task 
            GetStationsByRailwayId_OnSpecifiedRailway_ReturnsStationWithSpecifiedName(
            int railwayId,
            string expectedName)
        {
            var models = await ReadStationsOnARaiwayByRailwayId(railwayId);
            Assert.Contains(models, model => model.Name == expectedName);
        }

        [Theory]
        [InlineData(17, 53)]
        [InlineData(10095, 10024)]
        [InlineData(22, 10007)]
        public async Task 
            GetStationsByRailwayId_OnSpecifiedRailway_ReturnsStationWithSpecifiedId(
            int railwayId,
            int stationId)
        {
            var models = await ReadStationsOnARaiwayByRailwayId(railwayId);
            Assert.Contains(models, model => model.StationId == stationId);
        }

        [Theory]
        [InlineData(20, 0d)]
        [InlineData(10099, 33.856d)]
        public async Task
            GetStationsByRailwayId_OnExistingRailway_StationHasSpecifiedCentreKmPosts(
            int railwayId,
            decimal centreKmPost)
        {
            var models = await ReadStationsOnARaiwayByRailwayId(railwayId);
            Assert.Contains(models, model => model.CentreKmPost == centreKmPost);
        }

        private async Task<IEnumerable<StationOnARailwayDTO>> 
            ReadStationsOnARaiwayByRailwayId(int railwayId)
        {
            HttpResponseMessage response = 
                await RequestStationsLocationsByRailwayId(railwayId);
            var models = await DeserialiseAsync<
                IEnumerable<StationOnARailwayDTO>>(response);
            return models;
        }

        private async Task<HttpResponseMessage> 
            RequestStationsLocationsByRailwayId(int railwayId)
        {
            string url = STATION_ROOT_URL + byRailwayIdPath + railwayId;
            var response = await RequestGetAsync(url);
            return response;
        }
    }
}
