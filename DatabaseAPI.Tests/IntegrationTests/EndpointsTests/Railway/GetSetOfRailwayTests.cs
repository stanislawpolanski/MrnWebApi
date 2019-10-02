using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Railway
{
    public class GetSetOfRailwayTests : AbstractEndpointTests
    {
        private readonly string RAILWAY_API_URL = "/database-api/railway";
        public GetSetOfRailwayTests(WebApplicationFactory<Startup> injectedFactory) : base(injectedFactory)
        {
        }

        [Fact]
        public async Task Returns200OK()
        {
            HttpResponseMessage response = await RequestGetAsync(RAILWAY_API_URL);

            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
            HttpStatusCode actualStatusCode = response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task RailwayCountInASpecifiedRange()
        {
            int minimal = 20;
            int maximal = Int32.MaxValue;

            var response = await RequestGetAsync(RAILWAY_API_URL);

            List<RailwayDTO> dtos = await GetDTOsFromResponse(response);
            int actual = dtos.Count;
            Assert.InRange<int>(actual, minimal, maximal);
        }

        [Fact]
        public async Task EveryRailwayHasAppropriateUrl()
        {
            var response = await RequestGetAsync(RAILWAY_API_URL);
            var dtos = await GetDTOsFromResponse(response);

            Action<RailwayDTO> assertUrlValidity = dto => Assert.Equal(RAILWAY_API_URL + "/" + dto.Id, dto.Url);
            dtos.ForEach(assertUrlValidity);
        }


        [Theory]
        [InlineData(22, 1)]
        [InlineData(26, 16)]
        [InlineData(23, 2)]
        public async Task SpecifiedRailwaysHaveSpecifiedOwners(int railwayId, int ownerId)
        {
            var response = await RequestGetAsync(RAILWAY_API_URL);
            var dtos = await GetDTOsFromResponse(response);
            Predicate<RailwayDTO> railwayWithSpecifiedOwnerId = railway => railway.Id.Equals(railwayId) && railway.Owner.Id.Equals(ownerId);
            Assert.Contains<RailwayDTO>(dtos, railwayWithSpecifiedOwnerId);
        }

        private static async Task<List<RailwayDTO>> GetDTOsFromResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            List<RailwayDTO> dtos = JsonConvert.DeserializeObject<List<RailwayDTO>>(content);
            return dtos;
        }
    }
}
