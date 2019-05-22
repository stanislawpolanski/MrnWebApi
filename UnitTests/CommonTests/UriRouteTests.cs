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

            String actual = new UriRoute.Builder().Path("/simple").Path("route").Build().ToString();

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
        public void EscapesMultipleSlashes()
        {
            String expected = "/escapes/slashes";

            String actual = new UriRoute.Builder().Path("/////escapes").Path("slashes").Build().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EscapesSlashesInTheEnd()
        {
            String expected = "/escapes-slashes-in-the-end";

            String actual = new UriRoute.Builder().Path("escapes-slashes-in-the-end/////").Build().ToString();

            Assert.Equal(expected, actual);
        }
    }
}
