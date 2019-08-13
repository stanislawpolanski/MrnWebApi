using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.DTOs;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService :
        DbDataAccessAbstractService, IRailwayUnitDataAccessService
    {
        private ITextGeometryReader geometryReader;
        public DbRailwayUnitDataAccessService(
            MRN_developContext injectedContext,
            ITextGeometryReader injectedGeometryReader)
            : base(injectedContext)
        {
            geometryReader = injectedGeometryReader;
        }

        public async Task<RailwayUnitDTO>
            GetRailwayUnitByStationAsync(StationDTO station)
        {
            bool dataRequiredFromRequestIsIncomplete = (
                station.SerialisedGeometry == null
                || station.OwnerInfo.Id == 0);
            if (dataRequiredFromRequestIsIncomplete)
            {
                throw new ArgumentNullException();
            }
            return await GetRailwayUnitFromDatasource(station);
        }

        private async Task<RailwayUnitDTO> GetRailwayUnitFromDatasource(StationDTO station)
        {
            IGeometry stationDeserialisedGeometry = DeserialiseStationsGeometry(station);
            Expression<Func<RailwayUnits, bool>> unitOwnerEqualsStationsOwnerPredicate =
                unit => unit.OwnerId.Equals(station.OwnerInfo.Id);
            Expression<Func<RailwayUnits, bool>> unitsGeometryIntersectsStationsGeometryPredicate =
                unit => unit.Geometries.SpatialData.Intersects(stationDeserialisedGeometry);
            return await context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unitOwnerEqualsStationsOwnerPredicate)
                .Where(unitsGeometryIntersectsStationsGeometryPredicate)
                //todo to be replaced by dto builder
                .Select(unit => new RailwayUnitDTO()
                {
                    Id = unit.Id,
                    Name = unit.Name
                })
                .FirstOrDefaultAsync();
        }

        private IGeometry DeserialiseStationsGeometry(StationDTO station)
        {
            return geometryReader
                .Read(station.SerialisedGeometry.SerialisedSpatialData);
        }
    }
}
