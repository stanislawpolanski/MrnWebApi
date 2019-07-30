using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Railway
{
    public class DbRailwayDataAccessService : DbDataAccessAbstractService, IRailwayDataAccessService
    {
        public DbRailwayDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task<IEnumerable<RailwayModel>> GetRailwaysByStationIdAsync(int stationId)
        {
            IEnumerable<RailwayModel> result = await context
                .Railways
                .Include(railway => railway.StationsToGeometries)
                .Where(railway => railway.StationsToGeometries
                    .Any(stationToGeometry => stationToGeometry.StationId.Equals(stationId)))
                .Select(railwayEntity =>
                    new RailwayModel()
                    {
                        Id = railwayEntity.Id,
                        Name = railwayEntity.Name,
                        Number = railwayEntity.Number,
                        Owner = new OwnerModel()
                        {
                            Id = railwayEntity.Owner.Id,
                            Name = railwayEntity.Owner.Name
                        }
                    }
                )
                .ToListAsync();
            return result;
        }
    }
}
