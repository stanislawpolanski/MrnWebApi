﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace DatabaseAPI.Tests.IntegrationTests.EndpointsTests
{
    public class AbstractEndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<DatabaseAPI.Startup> factory;

        public AbstractEndpointTests(
            WebApplicationFactory<DatabaseAPI.Startup> injectedFactory)
        {
            factory = injectedFactory;
        }

        protected async System.Threading.Tasks.Task<HttpResponseMessage> GetResponseAsync(string url)
        {
            return await factory.CreateClient().GetAsync(url);
        }
    }
}
