using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService : DbDataAccessAbstractService, IRailwayUnitDataAccessService
    {
        public DbRailwayUnitDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public RailwayUnitModel GetRailwayUnitByStationId(int stationId)
        {
            //todo to be implemented
            return null;
        }
    }
}
