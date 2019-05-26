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

            String actual = new UriRoute.Builder().Path("/simple").Path("/route").Build().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreatesSimpleRouteWhenInputHasAndHasNoSlashes()
        {
            String expected = "/slash/no-slash";

            String actual = new UriRoute.Builder().Path("/slash").Path("no-slash").Build().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LowersCharacters()
        {
            String expected = "/lower/characters";

            String actual = new UriRoute.Builder().Path("/loWER").Path("/chaRACTERS").Build().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsExceptionWhenFindsSlasheInTheEnd()
        {
            //todo must be refactored in #28
            Assert.Throws<ForbiddenUseOfCharacterInStringException>(() => 
            new UriRoute.Builder().Path("finds-slashes-in-the-end/////").Build());
        }
    }
}
