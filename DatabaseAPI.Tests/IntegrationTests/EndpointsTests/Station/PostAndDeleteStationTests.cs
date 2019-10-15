using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Station
{
    public class PostAndDeleteStationTests : AbstractEndpointTests
    {
        public PostAndDeleteStationTests(
            WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task PostStationAsync_AssignsIdToStationWithNameAsync()
        {
            //arrange
            string newStationName = "Post station - test";
            int typeOfAStationId = 2;
            int ownerId = 1;
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = newStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerId = ownerId
                };
            //act
            var response = await RequestPostAsync<StationDTO>(
                STATION_ROOT_URL, 
                stationToPost);
            //assert
            StationDTO createdStation = await DeserialiseAsync<StationDTO>(response);
            try
            {
                Assert.Equal(newStationName, createdStation.Name);
                Assert.True(createdStation.Id > 0);
            }
            //clear
            finally
            {
                string deletionUrl =
                    STATION_ROOT_URL 
                    + createdStation.Id.ToString();
                await RequestDeleteAsync(deletionUrl);
            }
        }

        [Theory]
        [InlineData("/database-api/station", "Delete test station", 2, 1)]
        public async Task DeleteStationAsync_DeletesStation(
            string url,
            string newStationName,
            int typeOfAStationId,
            int ownerId)
        {
            //arrange
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = newStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerId = ownerId
                };
            var response = await RequestPostAsync<StationDTO>(
                STATION_ROOT_URL,
                stationToPost);
            var createdStation = await DeserialiseAsync<StationDTO>(response);
            string deletionUrl = UriRoute
                .GetRouteFromNodes(url, createdStation.Id.ToString())
                .ToString();
            //act
            var deletionResponse = await RequestDeleteAsync(deletionUrl);
            //assert
            Assert.Equal(HttpStatusCode.OK, deletionResponse.StatusCode);
        }
    }
}
