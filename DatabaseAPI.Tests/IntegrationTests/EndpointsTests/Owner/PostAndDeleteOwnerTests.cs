using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests.Owner
{
    public class PostAndDeleteOwnerTests : AbstractEndpointTests
    {
        public PostAndDeleteOwnerTests(
            WebApplicationFactory<Startup> injectedFactory) 
            : base(injectedFactory)
        {
        }

        [Fact]
        public async Task PutOwnerAsync_Returns200OKOnRequest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task PutOwnerAsync_ReturnsOwnerWithAssignedId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task PutOwnerAsyncWithoutName_Returns401BadRequest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task DeleteOwnerAsync_Returns204NoRequest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task DeleteNonExistingOwnerAsync_Returns404NotFound()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task DeleteOwnerAsync_Returns404NotFoundOnGetAfterDeleting()
        {
            throw new NotImplementedException();
        }
    }
}
