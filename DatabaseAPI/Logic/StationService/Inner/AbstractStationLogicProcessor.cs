﻿using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.ServicesFactory;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService.Inner
{
    public abstract class AbstractStationLogicProcessor
    {
        protected StationDTO station;
        protected DataAccessServicesFactory dataAccessServicesFactory;
        public void SetStation(StationDTO inputStation)
        {
            this.station = inputStation;
        }
        public void SetDataAccessServicesFactory(DataAccessServicesFactory
            inputDataAccessServicesFactory)
        {
            this.dataAccessServicesFactory = inputDataAccessServicesFactory;
        }
        public StationDTO GetStation()
        {
            return station;
        }
        public abstract Task ProcessStationRootAsync();
        public abstract Task ProcessGeometryWithRailwayUnitAsync();
        public abstract Task ProcessPhotosAsync();
        public abstract Task ProcessRailwaysAsync();
    }
}