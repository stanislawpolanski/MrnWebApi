using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using MrnWebApi.DataAccess.Services.StationToPhoto;

namespace MrnWebApi.DataAccess.Services.StationToRailway
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
            DeleteGeometryInfoFromRelationshipByStationidAsync(int stationId)
        {
            context
                .StationsToGeometries
                .Where(relationship => relationship.GeometryId.Equals(stationId))
                .ToList()
                .ForEach(entity => entity.GeometryId = null);
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

        public void UpdateRelationships(StationModel station, 
            IEnumerable<RailwayModel> railways)
        {
            throw new NotImplementedException();
        }
    }
}
