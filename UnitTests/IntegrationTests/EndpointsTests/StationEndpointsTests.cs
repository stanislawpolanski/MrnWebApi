using Microsoft.AspNetCore.Mvc.Testing;
using MrnWebApi.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.IntegrationTests.EndpointsTests
{
    public class StationEndpointsTests
        : IClassFixture<WebApplicationFactory<MrnWebApi.Startup>>
    {
        private readonly WebApplicationFactory<MrnWebApi.Startup> factory;

        public StationEndpointsTests(
            WebApplicationFactory<MrnWebApi.Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        [Theory]
        [InlineData("/api/station")]
        public async Task 
            GetAllStations_ReturnsAtLeastExpectedNumberOfStations(string url)
        {
            //arrange
            int expectedNumberOfStations = 200;
            //act
            var response = await GetResponseByUrl(url);
            List<StationModel> models = 
                await GetStationsListFromResponse(response);
            //assert
            response.EnsureSuccessStatusCode();
            Assert.True(models.Count >= expectedNumberOfStations);
        }

        private static async Task<List<StationModel>> 
            GetStationsListFromResponse(HttpResponseMessage response)
        {
            var text = await response.Content.ReadAsStringAsync();
            List<StationModel> models =
                JsonConvert
                .DeserializeObject<IEnumerable<StationModel>>(text)
                .ToList();
            return models;
        }

        [Theory]
        [InlineData("/api/station")]
        public async Task 
            GetAllStations_AllStationsContainsNameLongerThanSpecifiedNumber(string url)
        {
            //arrange
            int specifiedNameLength = 3;
            Action<StationModel> stationNameLongerThanSpecifiedNumber = 
                model => Assert.True(model.Name.Length > specifiedNameLength);
            //act
            var response = await GetResponseByUrl(url);
            List<StationModel> models =
                await GetStationsListFromResponse(response);
            //assert
            models.ForEach(stationNameLongerThanSpecifiedNumber);
        }

        [Theory]
        [InlineData("/api/station")]
        public async Task 
            GetAllStations_AllStationsContainsExpectedUrl(string endpointUrl)
        {
            //arrange
            var client = factory.CreateClient();
            Action<StationModel> actualUrlEqualsExpectedUrl = 
                model => Assert
                    .Equal(model.Url, endpointUrl + "/" + model.Id.ToString());
            //act
            var response = await GetResponseByUrl(endpointUrl);
            List<StationModel> models =
                await GetStationsListFromResponse(response);
            //assert 
            models.ForEach(actualUrlEqualsExpectedUrl);
        }

        [Theory]
        [InlineData("/api/station/78", "Trzebinia")]
        [InlineData("api/station/10112","Łęg Tarnowski")]
        public async Task 
            GetStationById_ReturnsStationWithExpectedName
                (string url, string expectedName)
        {
            //act
            StationModel station = 
                await GetDeserialisedTextFromResponseByUrl<StationModel>(url);
            //assert
            Assert.Equal(expectedName, station.Name);
        }

        private async Task<T> 
            GetDeserialisedTextFromResponseByUrl<T>(string url)
        {
            HttpResponseMessage response = await GetResponseByUrl(url);
            var text = await response.Content.ReadAsStringAsync();
            T result = DeserialiseJson<T>(text);
            return result;
        }

        private static T DeserialiseJson<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        private async Task<HttpResponseMessage> GetResponseByUrl(string url)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync(url);
            return response;
        }

        
        [Theory]
        [InlineData("/api/station/78", 5)]
        public async Task 
            GetStationById_ReturnsStationWithRailwaysAsync(string url, 
                int expectedNumberOfRailways)
        {
            StationModel model =
                await GetDeserialisedTextFromResponseByUrl<StationModel>(url);
            Assert.Equal(expectedNumberOfRailways, model.Railways.Count());
        }
        
        [Theory]
        [InlineData("api/station/78", 16)]
        public async Task GetStationById_ReturnsStationWithPhotosAsync(string url, 
            int expectedNumberOfPhotos)
        {
            StationModel model =
                await GetDeserialisedTextFromResponseByUrl<StationModel>(url);
            Assert.Equal(expectedNumberOfPhotos, model.Photos.Count());
        }

        
        [Theory]
        [InlineData("api/station/78", "POINT (532345.109 254186.948)")]
        public async Task GetStationById_ReturnsStationWithGeometry(string url, 
            string expectedGeometryValue)
        {
            StationModel model =
                await GetDeserialisedTextFromResponseByUrl<StationModel>(url);

            Assert.Equal(expectedGeometryValue, 
                model.SerialisedGeometry.SerialisedSpatialData);
        }
        
        [Theory]
        [InlineData("api/station/78", "KRAKÓW")]
        public async Task 
            GetStationById_ReturnsStationWithRailwayUnitAsync(string url,
                string expectedRailwayUnitName)
        {
            StationModel model =
                await GetDeserialisedTextFromResponseByUrl<StationModel>(url);

            Assert.Equal(expectedRailwayUnitName, model.RailwayUnit.Name);
        }

        [Fact]
        public void PostStation()
        {
            throw new Xunit.Sdk.XunitException("test not developed");
        }
        [Fact]
        public void PutStation()
        {
            throw new Xunit.Sdk.XunitException("test not developed");
        }
        [Fact]
        public void DeleteStation()
        {
            throw new Xunit.Sdk.XunitException("test not developed");
        }
    }
}

