using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;

namespace UnitTests.Mocks
{
    class MockedGeometryRailwayDataAccessService : IGeometryDataAccessService
    {
        public Task<GeometryModel> GetFirstGeometryByStationIdAsync(int id)
        {
            return null;
        }
    }
}
