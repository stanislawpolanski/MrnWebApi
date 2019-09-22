using DatabaseAPI.Common.Exceptions;
using DatabaseAPI.Common.Routing;
using Xunit;

namespace DatabaseAPI.Tests.UnitTests.CommonTests
{
    public class UriRouteTests
    {
        [Fact]
        public void CreatesSimpleRoute()
        {
            string expected = "/simple/route";
            UriRoute route = new UriRoute();
            route.AddNodesToTheRoute("/simple", "/route");

            string actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreatesSimpleRouteWhenInputHasAndHasNoSlashes()
        {
            string expected = "/slash/no-slash";
            UriRoute route = new UriRoute();
            route.AddNodesToTheRoute("/slash", "no-slash");

            string actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LowersCharacters()
        {
            string expected = "/lower/characters";
            UriRoute route = new UriRoute();
            route.AddNodesToTheRoute("/lowER", "/CHARacters");

            string actual = route.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsExceptionWhenFindsSlasheInTheEnd()
        {
            UriRoute route = new UriRoute();

            Assert.Throws<ForbiddenUseOfCharacterInAStringException>(() =>
                route.AddNodesToTheRoute("/simple/"));
        }

        [Fact]
        public void BuildPath_BuildsRoute()
        {
            string expected = "/some/route";

            string actual = UriRoute.GetRouteFromNodes("/some", "/route").ToString();

            Assert.Equal(actual, expected);
        }
    }
}
