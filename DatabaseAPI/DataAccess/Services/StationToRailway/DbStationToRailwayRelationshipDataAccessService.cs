using Microsoft.EntityFrameworkCore;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.DataAccess.Services.StationToPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.StationToRailway
{
    public class DbStationToRailwayRelationshipDataAccessService :
        DbDataAccessAbstractService,
        IStationToRailwayRelationshipDataAccessService
    {
        public DbStationToRailwayRelationshipDataAccessService
            (MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task
            ClearGeometryInfoFromRelationshipEntityByStationidAsync(int stationId)
        {
            Expression<Func<StationsToGeometries, bool>> pointsToRequiredStation =
                relationship => relationship.StationId.Equals(stationId);
            Action<StationsToGeometries> clearGeometryInfo =
                entity => entity.GeometryId = null;

            context
                .StationsToGeometries
                .Where(pointsToRequiredStation)
                .ToList()
                .ForEach(clearGeometryInfo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRelationshipsByStationIdAsync(int stationId)
        {
            IEnumerable<StationsToGeometries> stationsToGeometriesToBeDeleted =
                await GetRelationshipsToBeDeleted(stationId);
            context
                .StationsToGeometries
                .RemoveRange(stationsToGeometriesToBeDeleted);
            await context.SaveChangesAsync();
        }

        private Task<List<StationsToGeometries>> GetRelationshipsToBeDeleted(int stationId)
        {
            return context
                .StationsToGeometries
                .Where(rel => rel.StationId.Equals(stationId))
                .ToListAsync();
        }

        public void UpdateRelationships(StationDTO station,
            IEnumerable<RailwayDTO> railways)
        {
            throw new NotImplementedException();
        }
    }
}
