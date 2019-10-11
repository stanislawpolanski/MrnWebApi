using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Station
{
    public class PutStationTests : AbstractEndpointTests
    {
        public PutStationTests(WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task PutStationAsync_Returns204OnRequest()
        {
            //arrange
            //todo to be refactored to dto builder
            string originalStationName = "Put station test - original name";
            string updatedStationName = "Put station test - updated name";
            int typeOfAStationId = 2;
            int ownerId = 1;
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = originalStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerId = ownerId
                };
            var postResponse = await RequestPostAsync<StationDTO>(STATION_ROOT_URL, stationToPost);
            StationDTO createdStation = await DeserialiseAsync<StationDTO>(postResponse);
            StationDTO putStation =
                new StationDTO()
                {
                    Id = createdStation.Id,
                    Name = updatedStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerId = ownerId
                };
            string putUrl = STATION_ROOT_URL + createdStation.Id.ToString();
            try
            {
                //act
                var putResponse = await RequestPutAsync<StationDTO>(putUrl, putStation);
                //assert
                Assert.Equal(
                    HttpStatusCode.NoContent,
                    putResponse.StatusCode);
            }
            finally
            {
                //clear
                string deletionUrl = STATION_ROOT_URL + createdStation.Id.ToString();
                await RequestDeleteAsync(deletionUrl);
            }
        }
    }
}
