using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.RailwayUnit
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
                || station.OwnerId == 0);
            if (dataRequiredFromRequestIsIncomplete)
            {
                return null;
            }
            return await ReadRailwayUnitFromDatasourceByStationAsync(station);
        }

        private async Task<RailwayUnitDTO>
            ReadRailwayUnitFromDatasourceByStationAsync(StationDTO station)
        {
            return await context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(GetOwnersEqualityPredicate(station))
                .Where(GetGeometryIntersectionPredicate(station))
                .Select(entity => RailwayUnitMapper.MapToDTO(entity))
                .FirstOrDefaultAsync();
        }

        private Expression<Func<RailwayUnits, bool>>
            GetOwnersEqualityPredicate(StationDTO station)
        {
            return unit => unit.OwnerId.Equals(station.OwnerId);
        }

        private Expression<Func<RailwayUnits, bool>>
            GetGeometryIntersectionPredicate(StationDTO station)
        {
            IGeometry stationGeometry = DeserialiseStationsGeometry(station);
            return unit =>
                unit
                .Geometries
                .SpatialData
                .Intersects(stationGeometry);
        }

        private IGeometry DeserialiseStationsGeometry(StationDTO station)
        {
            return geometryReader
                .Read(station.SerialisedGeometry.SerialisedSpatialData);
        }
    }
}
