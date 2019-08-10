using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MrnWebApi.Controllers;
using MrnWebApi.Logic.StationService;
using MrnWebApi.DataAccess.ServicesFactory;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MrnWebApi.Common.Models;
using System.Linq;

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
            var client = factory.CreateClient();
            //act
            var response = await client.GetAsync(url);
            var text = await response.Content.ReadAsStringAsync();
            List<StationModel> models = 
                JsonConvert
                .DeserializeObject<IEnumerable<StationModel>>(text)
                .ToList();
            //assert
            response.EnsureSuccessStatusCode();
            Assert.True(models.Count >= expectedNumberOfStations);
        }

        /*
        [Fact]
        public void GetAllTheStations()
        {
            throw new Xunit.Sdk.XunitException("test not developed");
        }
        
        
        [Fact]
        public void GetSingleStation()
        {
            throw new Xunit.Sdk.XunitException("test not developed");
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
        }*/
    }
}

