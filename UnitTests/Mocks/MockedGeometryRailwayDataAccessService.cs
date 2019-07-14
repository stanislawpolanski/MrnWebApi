using System;
using System.Collections.Generic;
using System.Text;
using GeoAPI.Geometries;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;

namespace UnitTests.Mocks
{
    class MockedGeometryRailwayDataAccessService : IGeometryDataAccessService
    {
        public GeometryModel GetFirstGeometryByStationId(int id)
        {
            return null;
        }
    }
}
