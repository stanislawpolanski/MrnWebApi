using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.Services.StationToPhoto;
using System;

namespace DatabaseAPI.DataAccess.ServicesFactory
{
    [Obsolete]
    public class DataAccessServicesFactory
    {
        [Obsolete]
        public IStationDataAccessService StationDataAccessService { get; private set; }
        [Obsolete]
        public IPhotoDataAccessService PhotoDataAccessService { get; private set; }
        [Obsolete]
        public IRailwayDataAccessService RailwayDataAccessService { get; private set; }
        [Obsolete]
        public IRailwayUnitDataAccessService RailwayUnitDataAccessService { get; private set; }
        [Obsolete]
        public IGeometryDataAccessService GeometryDataAccessService { get; private set; }
        [Obsolete]
        public IStationToPhotoRelationshipDataAccessService StationToPhotoRelationshipDataAccessService
        { get; private set; }
        public IStationToRailwayRelationshipDataAccessService StationToRailwayRelationshipDataAccessService
        { get; private set; }
        [Obsolete]
        public DataAccessServicesFactory(IStationDataAccessService injectedStationDataAccessService,
            IPhotoDataAccessService injectedPhotosDataAccessSercice,
            IRailwayDataAccessService injectedRailwaysDataAccessService,
            IRailwayUnitDataAccessService injectedRailwayUnitDataAccessService,
            IGeometryDataAccessService injectedGeometryDataAccessService,
            IStationToPhotoRelationshipDataAccessService injectedStationToPhotoRelationshipDataAccessService,
            IStationToRailwayRelationshipDataAccessService injectedStationToRailwayRelationshipDataAccessService)
        {
            StationDataAccessService = injectedStationDataAccessService;
            PhotoDataAccessService = injectedPhotosDataAccessSercice;
            RailwayDataAccessService = injectedRailwaysDataAccessService;
            RailwayUnitDataAccessService = injectedRailwayUnitDataAccessService;
            GeometryDataAccessService = injectedGeometryDataAccessService;
            StationToPhotoRelationshipDataAccessService = injectedStationToPhotoRelationshipDataAccessService;
            StationToRailwayRelationshipDataAccessService = injectedStationToRailwayRelationshipDataAccessService;
        }
    }
}
