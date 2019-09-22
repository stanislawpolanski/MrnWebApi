﻿using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests
{
    public class StationEndpointsTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public StationEndpointsTests(
            WebApplicationFactory<Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        [Theory]
        [InlineData("/database-api/station")]
        public async Task
            GetAllStations_ReturnsAtLeastExpectedNumberOfStations(string url)
        {
            //arrange
            int expectedNumberOfStations = 200;
            //act
            var response = await GetResponseByUrl(url);
            List<StationDTO> models =
                await GetStationsListFromResponse(response);
            //assert
            response.EnsureSuccessStatusCode();
            Assert.True(models.Count >= expectedNumberOfStations);
        }

        private static async Task<List<StationDTO>>
            GetStationsListFromResponse(HttpResponseMessage response)
        {
            var text = await response.Content.ReadAsStringAsync();
            List<StationDTO> models =
                JsonConvert
                .DeserializeObject<IEnumerable<StationDTO>>(text)
                .ToList();
            return models;
        }

        [Theory]
        [InlineData("/database-api/station")]
        public async Task
            GetAllStations_AllStationsContainsNameLongerThanSpecifiedNumber(string url)
        {
            //arrange
            int specifiedNameLength = 3;
            Action<StationDTO> stationNameLongerThanSpecifiedNumber =
                model => Assert.True(model.Name.Length > specifiedNameLength);
            //act
            var response = await GetResponseByUrl(url);
            List<StationDTO> models =
                await GetStationsListFromResponse(response);
            //assert
            models.ForEach(stationNameLongerThanSpecifiedNumber);
        }

        [Theory]
        [InlineData("/database-api/station")]
        public async Task
            GetAllStations_AllStationsContainsExpectedUrl(string endpointUrl)
        {
            //arrange
            var client = factory.CreateClient();
            Action<StationDTO> actualUrlEqualsExpectedUrl =
                model => Assert
                    .Equal(model.Url, endpointUrl + "/" + model.Id.ToString());
            //act
            var response = await GetResponseByUrl(endpointUrl);
            List<StationDTO> models =
                await GetStationsListFromResponse(response);
            //assert 
            models.ForEach(actualUrlEqualsExpectedUrl);
        }

        [Theory]
        [InlineData("/database-api/station", 78, "Trzebinia")]
        [InlineData("/database-api/station", 10112, "Łęg Tarnowski")]
        public async Task
            GetAllStations_ContainsSpecificStation(string url, int id, string name)
        {
            //arrange
            var client = factory.CreateClient();
            //act
            var response = await GetResponseByUrl(url);
            List<StationDTO> models =
                await GetStationsListFromResponse(response);
            //assert
            Predicate<StationDTO> containsSpecificStation = station =>
                station.Id.Equals(id) &&
                station.Name.Equals(name);
            Assert.Contains(models, containsSpecificStation);
        }

        [Theory]
        [InlineData("/database-api/station/78", "Trzebinia")]
        [InlineData("/database-api/station/10112", "Łęg Tarnowski")]
        [InlineData("/database-api/station/168", "Szczakowa Południe")]
        public async Task
            GetStationById_ReturnsStationWithExpectedName
                (string url, string expectedName)
        {
            //act
            StationDTO station =
                await GetObjectFromResponseTextByUrl<StationDTO>(url);
            //assert
            Assert.Equal(expectedName, station.Name);
        }

        private async Task<T>
            GetObjectFromResponseTextByUrl<T>(string url)
        {
            HttpResponseMessage response = await GetResponseByUrl(url);
            T result = await DeserialiseObjectFromResponse<T>(response);
            return result;
        }

        private static async Task<T>
            DeserialiseObjectFromResponse<T>(HttpResponseMessage response)
        {
            var text = await response.Content.ReadAsStringAsync();
            T result = DeserialiseObjectFromString<T>(text);
            return result;
        }

        private static T DeserialiseObjectFromString<T>(string text)
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
        [InlineData("/database-api/station/78", "POINT (532345.109 254186.948)")]
        public async Task GetStationById_ReturnsStationWithGeometry(string url,
            string expectedGeometryValue)
        {
            StationDTO model =
                await GetObjectFromResponseTextByUrl<StationDTO>(url);

            Assert.Equal(expectedGeometryValue,
                model.SerialisedGeometry.SerialisedSpatialData);
        }

        [Theory]
        [InlineData("/database-api/station/78", "Kraków")]
        public async Task
            GetStationById_ReturnsStationWithRailwayUnitAsync(string url,
                string expectedRailwayUnitName)
        {
            StationDTO model =
                await GetObjectFromResponseTextByUrl<StationDTO>(url);

            Assert.Equal(expectedRailwayUnitName, model.RailwayUnit.Name);
        }

        [Theory]
        [InlineData("/database-api/station", "Post test station", 2, 1)]
        public async Task PostStationAsync_AssignsIdToStationWithNameAsync(
            string url,
            string newStationName,
            int typeOfAStationId,
            int ownerId)
        {

            //arrange
            var client = factory.CreateClient();
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = newStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerInfo = new OwnerDTO()
                    {
                        Id = ownerId
                    }
                };
            //act
            HttpResponseMessage response = await client
                .PostAsJsonAsync(url, stationToPost);
            var text = response.Content.ReadAsStringAsync().Result;
            StationDTO createdStation =
                DeserialiseObjectFromString<StationDTO>(text);
            //assert
            Assert.Equal(newStationName, createdStation.Name);
            Assert.True(createdStation.Id > 0);
            //clear
            string deletionUrl = UriRoute
                .GetRouteFromNodes(url, createdStation.Id.ToString())
                .ToString();
            await client.DeleteAsync(deletionUrl);
        }

        [Theory]
        [InlineData("/database-api/station", "Put test station", "Put test station, changed name", 2, 1)]
        public async Task PutStationAsync_Returns204OnRequest(
            string url,
            string originalStationName,
            string changedStationName,
            int typeOfAStationId,
            int ownerId)
        {
            //arrange
            var client = factory.CreateClient();
            //todo to be refactored to dto builder
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = originalStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerInfo = new OwnerDTO()
                    {
                        Id = ownerId
                    }
                };
            HttpResponseMessage postResponse = await client
              .PostAsJsonAsync(url, stationToPost);
            var text = postResponse.Content.ReadAsStringAsync().Result;
            StationDTO createdStation =
                DeserialiseObjectFromString<StationDTO>(text);
            StationDTO putStation =
                new StationDTO()
                {
                    Id = createdStation.Id,
                    Name = changedStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerInfo = new OwnerDTO()
                    {
                        Id = ownerId
                    }
                };
            string putUrl =
                UriRoute
                    .GetRouteFromNodes(
                        url,
                        createdStation.Id.ToString())
                    .ToString();
            try
            {
                //act
                HttpResponseMessage response = await
                    client.PutAsJsonAsync(putUrl, putStation);
                //assert
                Assert.Equal(
                    HttpStatusCode.NoContent,
                    response.StatusCode);
            }
            finally
            {
                //clear
                string deletionUrl = UriRoute
                    .GetRouteFromNodes(url, createdStation.Id.ToString())
                    .ToString();
                await client.DeleteAsync(deletionUrl);
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
            var client = factory.CreateClient();
            StationDTO stationToPost =
                new StationDTO()
                {
                    Name = newStationName,
                    TypeOfAStationInfo = new TypeOfAStationDTO()
                    {
                        Id = typeOfAStationId
                    },
                    OwnerInfo = new OwnerDTO()
                    {
                        Id = ownerId
                    }
                };
            HttpResponseMessage response = await client
                .PostAsJsonAsync<StationDTO>(url, stationToPost);
            string text = await response.Content.ReadAsStringAsync();
            StationDTO createdStation =
                DeserialiseObjectFromString<StationDTO>(text);
            string deletionUrl = UriRoute
                .GetRouteFromNodes(url, createdStation.Id.ToString())
                .ToString();
            //act
            await client.DeleteAsync(deletionUrl);
            //assert
            Assert.Equal(
                HttpStatusCode.OK,
                response.StatusCode);
        }
    }
}

