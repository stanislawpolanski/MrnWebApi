using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using MrnWebApi.DataAccess.Services.StationToPhoto;

namespace MrnWebApi.DataAccess.Services.StationToRailway
{
    public class DbStationToRailwayRelationshipDataAccessService : 
        DbDataAccessAbstractService, 
        IStationToRailwayRelationshipDataAccessService
    {
        public DbStationToRailwayRelationshipDataAccessService(MRN_developContext injectedContext) : 
            base(injectedContext)
        {
        }

        public void UpdateRelationships(StationModel station, IEnumerable<RailwayModel> railways)
        {
            throw new NotImplementedException();
        }
    }
}
