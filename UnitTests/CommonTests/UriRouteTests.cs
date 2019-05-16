using Microsoft.AspNetCore.Routing;
using MrnWebApi.Common;
using MrnWebApi.Common.Exceptions;
using System;
using Xunit;

namespace UnitTests.CommonTests
{
    public class UriRouteTests
    {
        [Fact]
        public void CreatesSimpleRoute()
        {
            String expected = "/simple/route";

            String actual = new UriRoute.Builder().Path("/simple").PathWithSlash("route").Build().GetRoute();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void LowersCharacters()
        {
            String expected = "/lower/characters";

            String actual = new UriRoute.Builder().Path("/loWER").Path("/chaRACTERS").Build().GetRoute();

            Assert.Equal(actual, expected);
        }
    }
}
