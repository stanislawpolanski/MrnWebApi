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

            String actual = new UriRoute.Builder().Path("simple").Path("route").Build().GetRoute();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void LowersCharacters()
        {
            String expected = "/lower/characters";

            String actual = new UriRoute.Builder().Path("loWER").Path("chaRACTERS").Build().GetRoute();

            Assert.Equal(actual, expected);
        }
        
        [Fact]
        public void ForbidsInternalSlashes()
        {
            Assert.Throws<ForbiddenCharacter>(() => new UriRoute.Builder().Path("slashes").Path("/forbidden").Build());
        }
    }
}
