using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Railway
{
    public class GetSingleRailwayTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<DatabaseAPI.Startup> factory;

        public GetSingleRailwayTests(
            WebApplicationFactory<DatabaseAPI.Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        [Theory]
        [InlineData("/database-api/railway/2")]
        [InlineData("/database-api/railway/23")]
        public async Task Returns200OnExistingRailway(string url)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("/database-api/railway/123456789")]
        public async Task Returns404OnNonExistingRailway(string url)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("/database-api/railway/23")]
        public async Task ReturnsNameOfTheRailway(string url)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("/database-api/railway/23")]
        public async Task ReturnsNumberOfTheRailway(string url)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("/database-api/railway/23")]
        public async Task ReturnsOwnerOfTheRailway(string url)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("/database-api/railway/23")]
        public async Task ReturnsStationsWithKmPostsForRailway(string url)
        {
            throw new NotImplementedException();
        }
    }
}
