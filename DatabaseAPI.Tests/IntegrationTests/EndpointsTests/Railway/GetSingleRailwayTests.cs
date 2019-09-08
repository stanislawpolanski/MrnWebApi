﻿using DatabaseAPI.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Railway
{
    public class GetSingleRailwayTests : AbstractEndpointTests
    {
        public GetSingleRailwayTests(WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Theory]
        [InlineData("/database-api/railway/2")]
        [InlineData("/database-api/railway/23")]
        public async Task Returns200OnExistingRailway(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/database-api/railway/123456789")]
        public async Task Returns404OnNonExistingRailway(string url)
        {
            var response = await GetGetResponseAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        private async Task<RailwayDTO> GetRailwayDTOByUrl(string url)
        {
            HttpResponseMessage response = await GetGetResponseAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            RailwayDTO dto = JsonConvert.DeserializeObject<RailwayDTO>(content);
            return dto;
        }

        [Theory]
        [InlineData("/database-api/railway/23", "Jęzor Centralny Jca - Trzebinia Siersza")]
        [InlineData("/database-api/railway/10609", "Tarnów Filia - Tarnów Wschód")]
        public async Task ReturnsNameOfTheRailway(string url, string name)
        {
            RailwayDTO dto = await GetRailwayDTOByUrl(url);
            Assert.Equal(name, dto.Name);
        }


        [Theory]
        [InlineData("/database-api/railway/10138", 138)]
        public async Task ReturnsNumberOfTheRailway(string url, int number)
        {
            RailwayDTO dto = await GetRailwayDTOByUrl(url);
            Assert.Equal(number, dto.Number);
        }

        [Theory]
        [InlineData("/database-api/railway/22", 1, "PKP PLK")]
        public async Task ReturnsOwnerOfTheRailway(
            string url, 
            int ownerId, 
            string ownerName)
        {
            RailwayDTO dto = await GetRailwayDTOByUrl(url);
            Assert.Equal(ownerId, dto.Owner.Id);
            Assert.Equal(ownerName, dto.Owner.Name);
        }

        [Theory]
        [InlineData("/database-api/railway/26", 2)]
        public async Task ReturnsNotLessStationsWithKmPostsForRailway(
            string url, 
            int minimalStationsNumber)
        {
            RailwayDTO dto = await GetRailwayDTOByUrl(url);
            Assert.NotNull(dto.StationsKmPosts);
            Assert.True(dto.StationsKmPosts.ToList().Count >= minimalStationsNumber);
        }
    }
}