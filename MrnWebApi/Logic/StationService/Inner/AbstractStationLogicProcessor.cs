using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.ServicesFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService.Inner
{
    public abstract class AbstractStationLogicProcessor
    {
        protected StationModel station;
        protected DataAccessServicesFactory dataAccessServicesFactory;
        public void SetStation(StationModel inputStation)
        {
            this.station = inputStation;
        }
        public void SetDataAccessServicesFactory(DataAccessServicesFactory
            inputDataAccessServicesFactory)
        {
            this.dataAccessServicesFactory = inputDataAccessServicesFactory;
        }
        public StationModel GetStation()
        {
            return station;
        }
        public abstract Task ProcessStationRootAsync();
        public abstract Task ProcessGeometryWithRailwayUnitAsync();
        public abstract Task ProcessPhotosAsync();
        public abstract Task ProcessRailwaysAsync();
    }
}
