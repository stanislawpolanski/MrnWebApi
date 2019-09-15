using DatabaseAPI.DataAccess.Inner.Scaffold;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.RollingStock
{
    public class PostSingleRollingStockTests : AbstractEndpointTests
    {
        public PostSingleRollingStockTests(
            WebApplicationFactory<Startup> factory) : base(factory)
        {
        }
    }
}
