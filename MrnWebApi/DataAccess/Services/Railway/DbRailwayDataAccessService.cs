using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Expression<System.Func<Railways, bool>> railwaysHasStation = 
                railway => 
                    railway
                    .StationsToGeometries
                    .Any(stationToGeometry => 
                        stationToGeometry.StationId.Equals(stationId));

            IEnumerable<RailwayModel> result = await context
                .Railways
                .Include(railway => railway.StationsToGeometries)
                .Where(railwaysHasStation)
                //todo to be replaced by dto builder
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
