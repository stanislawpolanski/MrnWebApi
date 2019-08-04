using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<RailwayUnitModel>
            GetRailwayUnitByStationAsync(StationModel station)
        {
            bool requiredDataIsNull = (station.SerialisedGeometry == null || station.OwnerInfo.Id == 0);
            if (requiredDataIsNull)
            {
                throw new ArgumentNullException();
            }
            return await GetRailwayUnitFromDatasource(station);
        }

        private async Task<RailwayUnitModel> GetRailwayUnitFromDatasource(StationModel station)
        {
            IGeometry stationDeserialisedGeometry = DeserialiseStationsGeometry(station);
            Expression<Func<RailwayUnits, bool>> unitOwnerEqualsStationsOwnerPredicate =
                unit => unit.OwnerId.Equals(station.OwnerInfo.Id);
            Expression<Func<RailwayUnits, bool>> unitsGeometryIntersectsStationsPredicate =
                unit => unit.Geometries.SpatialData.Intersects(stationDeserialisedGeometry);
            return await context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unitOwnerEqualsStationsOwnerPredicate)
                .Where(unitsGeometryIntersectsStationsPredicate)
                .Select(unit => new RailwayUnitModel()
                {
                    Id = unit.Id,
                    Name = unit.Name
                })
                .FirstOrDefaultAsync();
        }

        private IGeometry DeserialiseStationsGeometry(StationModel station)
        {
            return geometryReader
                .Read(station.SerialisedGeometry.SerialisedSpatialData);
        }
    }
}
