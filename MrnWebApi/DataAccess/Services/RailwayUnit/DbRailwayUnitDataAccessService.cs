using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService : DbDataAccessAbstractService, IRailwayUnitDataAccessService
    {
        public DbRailwayUnitDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public RailwayUnitModel GetRailwayUnitByStationId(int stationId)
        {

            int stationOwnerId = context
                .Stations
                .Where(station => station.Id.Equals(stationId))
                .Include(station => station.ParentObjectOfInterest)
                .FirstOrDefault()
                .ParentObjectOfInterest
                .OwnerId;

            IGeometry stationGeometry = context
                .StationsToGeometries
                .Where(relation => relation.StationId.Equals(stationId))
                .Include(relation => relation.Geometry)
                .Select(entity => entity.Geometry.SpatialData)
                .First();

            return context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unit => unit.OwnerId.Equals(stationOwnerId))
                .Where(unit => unit.Geometries.SpatialData.Intersects(stationGeometry))
                .Select(unit => new RailwayUnitModel()
                {
                    Id = unit.Id,
                    Name = unit.Name
                })
                .First();
        }
    }
}
