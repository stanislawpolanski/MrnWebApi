using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService : IRailwayUnitDataAccessService
    {
        private MRN_developContext dbContext;
        public DbRailwayUnitDataAccessService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
        }

        public RailwayUnitModel GetRailwayUnitByStationId(int stationId)
        {
            //todo to be implemented
            return null;
        }
    }
}
