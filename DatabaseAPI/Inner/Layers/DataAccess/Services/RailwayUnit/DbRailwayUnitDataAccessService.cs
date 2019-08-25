using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.DTOs.FromEntitiesAdapters;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.RailwayUnit
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
                || station.OwnerInfo == null);
            if (dataRequiredFromRequestIsIncomplete)
            {
                return null;
            }
            return await GetRailwayUnitFromDatasource(station);
        }

        private async Task<RailwayUnitDTO> 
            GetRailwayUnitFromDatasource(StationDTO station)
        {
            if (station.SerialisedGeometry == null || station.OwnerInfo == null)
            {
                return null;
            }

            IGeometry stationDeserialisedGeometry = DeserialiseStationsGeometry(station);
            Expression<Func<RailwayUnits, bool>> unitOwnerEqualsStationsOwnerPredicate =
                unit => unit.OwnerId.Equals(station.OwnerInfo.Id);
            Expression<Func<RailwayUnits, bool>> 
                unitsGeometryIntersectsStationsGeometryPredicate = unit => 
                unit.Geometries.SpatialData.Intersects(stationDeserialisedGeometry);
            Expression<Func<RailwayUnits, RailwayUnitEntityToRailwayUnitDTOAdapter>> 
                selectToDTO = unitEntity =>
                    new RailwayUnitEntityToRailwayUnitDTOAdapter(unitEntity);

            return await context
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unitOwnerEqualsStationsOwnerPredicate)
                .Where(unitsGeometryIntersectsStationsGeometryPredicate)
                .Select(selectToDTO)
                .FirstOrDefaultAsync();
        }

        private IGeometry DeserialiseStationsGeometry(StationDTO station)
        {
            return geometryReader
                .Read(station.SerialisedGeometry.SerialisedSpatialData);
        }
    }
}
