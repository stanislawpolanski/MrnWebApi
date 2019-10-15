using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Station
{
    public class GetSingleStationTests : AbstractEndpointTests
    {
        public GetSingleStationTests(
            WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Theory]
        [InlineData("/database-api/station/78", "Trzebinia")]
        [InlineData("/database-api/station/10112", "Łęg Tarnowski")]
        [InlineData("/database-api/station/168", "Szczakowa Południe")]
        public async Task GetStationById_ReturnsStationWithExpectedName(
            string url,
            string expectedName)
        {
            var response = await RequestGetAsync(url);
            var station = await DeserialiseAsync<StationDTO>(response);
            Assert.Equal(expectedName, station.Name);
        }

        [Theory]
        [InlineData("/database-api/station/78", "POINT (532345.109 254186.948)")]
        public async Task GetStationById_ReturnsStationWithGeometry(
            string url,
            string expectedGeometryValue)
        {
            var response = await RequestGetAsync(url);
            var model = await DeserialiseAsync<StationDTO>(response);
            Assert.Equal(
                expectedGeometryValue,
                model.SerialisedGeometry.SerialisedSpatialData);
        }

        [Theory]
        [InlineData("/database-api/station/78", "Kraków")]
        public async Task GetStationById_ReturnsStationWithRailwayUnitAsync(
            string url,
            string expectedRailwayUnitName)
        {
            var response = await RequestGetAsync(url);
            var model = await DeserialiseAsync<StationDTO>(response);
            Assert.Equal(expectedRailwayUnitName, model.RailwayUnit.Name);
        }
    }
}
