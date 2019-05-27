using Microsoft.AspNetCore.Routing;
using MrnWebApi.Common;
using MrnWebApi.Common.Exceptions;
using MrnWebApi.Common.Routing;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.CommonTests
{
    public class UriRouteTests
    {
        [Fact]
        public void CreatesSimpleRoute()
        {
            String expected = "/simple/route";
            UriRoute route = new UriRoute();
            route.AddPaths(new List<String>() { "/simple", "/route" });

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreatesSimpleRouteWhenInputHasAndHasNoSlashes()
        {
            String expected = "/slash/no-slash";
            UriRoute route = new UriRoute();
            route.AddPaths(new List<String>() { "/slash", "no-slash" });

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LowersCharacters()
        {
            String expected = "/lower/characters";
            UriRoute route = new UriRoute();
            route.AddPaths(new List<String>() { "/lowER", "/CHARacters" });

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsExceptionWhenFindsSlasheInTheEnd()
        {
            UriRoute route = new UriRoute();
            
            Assert.Throws<ForbiddenUseOfCharacterInAStringException>(() => 
                route.AddPaths(new List<String>() { "/simple/"}));
        }

        [Fact]
        public void BuilderBuildsRoute()
        {
            String expected = "/some/route";

            String actual = new UriRoute.Builder().Path("/some").Path("/route").Build().ToString();

            Assert.Equal(actual, expected);
        }
    }
}
