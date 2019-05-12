using MrnWebApi.Common.Models;
using System;
using System.Collections.Generic;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Station
{
    public class DbStationDataAccessService : IStationDataAccessService
    {
        private MRN_developContext dbContext;

        public DbStationDataAccessService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
        }

        public IEnumerable<BasicStationModel> GetBasicStations()
        {
            return dbContext.Stations
                .Join(dbContext.ObjectsOfInterest, 
                    s => s.Id, 
                    o => o.Id, 
                    (s, o) => new BasicStationModel { Id = s.Id, Name = o.Name})
                .Distinct()
                .ToList();
        }
    }
}
