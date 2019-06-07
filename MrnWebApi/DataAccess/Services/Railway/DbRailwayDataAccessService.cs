using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Railway
{
    public class DbRailwayDataAccessService : DbDataAccessAbstractService, IRailwayDataAccessService
    {
        public DbRailwayDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public IEnumerable<RailwayModel> GetRailwaysByStationId(int stationId)
        {
            return dbContext
                .Railways
                .Where(railway => railway.StationsToGeometries.FirstOrDefault().StationId.Equals(stationId))
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
                .ToList();
        }
    }
}
