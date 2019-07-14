using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Geometry;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using NetTopologySuite.IO;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService : DbDataAccessAbstractService, IRailwayUnitDataAccessService
    {
        private ITextGeometryReader geometryReader;
        public DbRailwayUnitDataAccessService(MRN_developContext injectedContext,
            ITextGeometryReader injectedGeometryReader) : base(injectedContext)
        {
            geometryReader = injectedGeometryReader;
        }

        public RailwayUnitModel GetRailwayUnitByStation(StationModel station)
        {
            IGeometry point = geometryReader.Read(station.SerialisedGeometry.SerialisedSpatialData);

            return context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unit => unit.OwnerId.Equals(station.OwnerInfo.Id))
                .Where(unit => unit.Geometries.SpatialData.Intersects(point))
                .Select(unit => new RailwayUnitModel()
                {
                    Id = unit.Id,
                    Name = unit.Name
                })
                .First();
        }
    }
}
