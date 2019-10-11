using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Station
{
    public class GetCollectionOfStationsTests : AbstractEndpointTests
    {
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

        [Fact]
        public async Task GetStationsByRailwayId_OnExistingRailway_Returns200OK()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetStationsByRailwayId_OnNonExistingRailway_Returns404NotFound()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetStationsByRailwayId_OnExistingRailway_ReturnsNumberOfStations()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetStationsByRailwayId_OnSpecifiedRailway_ReturnsStationWithSpecifiedName()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetStationsByRailwayId_OnSpecifiedRailway_ReturnsStationWithSpecifiedId()
        {
            throw new NotImplementedException();
        }
    }
}
