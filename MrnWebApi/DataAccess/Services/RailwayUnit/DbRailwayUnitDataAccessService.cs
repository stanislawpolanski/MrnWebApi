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

        public RailwayUnitModel GetRailwayUnitByStation(StationModel station)
        {
            return context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unit => unit.OwnerId.Equals(station.OwnerInfo.Id))
                .Where(unit => unit.Geometries.SpatialData.Intersects(station.LocationGeometry))
                .Select(unit => new RailwayUnitModel()
                {
                    Id = unit.Id,
                    Name = unit.Name
                })
                .First();
        }
    }
}
