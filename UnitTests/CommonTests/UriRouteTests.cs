using MrnWebApi.Common.Exceptions;
using MrnWebApi.Common.Routing;
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
            UriRoute route = new UriRoute();
            route.AddPaths("/simple", "/route");

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreatesSimpleRouteWhenInputHasAndHasNoSlashes()
        {
            String expected = "/slash/no-slash";
            UriRoute route = new UriRoute();
            route.AddPaths("/slash", "no-slash");

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LowersCharacters()
        {
            String expected = "/lower/characters";
            UriRoute route = new UriRoute();
            route.AddPaths("/lowER", "/CHARacters");

            String actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsExceptionWhenFindsSlasheInTheEnd()
        {
            UriRoute route = new UriRoute();

            Assert.Throws<ForbiddenUseOfCharacterInAStringException>(() =>
                route.AddPaths("/simple/"));
        }

        [Fact]
        public void BuildPath_BuildsRoute()
        {
            String expected = "/some/route";

            String actual = UriRoute.BuildRoute("/some", "/route").ToString();

            Assert.Equal(actual, expected);
        }
    }
}
