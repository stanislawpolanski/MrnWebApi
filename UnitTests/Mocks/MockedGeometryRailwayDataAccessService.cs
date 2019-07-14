using System;
using System.Collections.Generic;
using System.Text;
using GeoAPI.Geometries;

namespace UnitTests.Mocks
{
    class MockedGeometryRailwayDataAccessService : MrnWebApi.DataAccess.Services.Geometry.IGeometryDataAccessService
    {
        public IGeometry GetFirstGeometryByStationId(int id)
        {
            return null;
        }
    }
}
