using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.Services.StationToPhoto;

namespace DatabaseAPI.DataAccess.ServicesFactory
{
    public class DataAccessServicesFactory
    {

        public IStationDataAccessService StationDataAccessService { get; private set; }
        public IPhotoDataAccessService PhotoDataAccessService { get; private set; }
        public IRailwayDataAccessService RailwayDataAccessService { get; private set; }
        public IRailwayUnitDataAccessService RailwayUnitDataAccessService { get; private set; }
        public IGeometryDataAccessService GeometryDataAccessService { get; private set; }
        public IStationToPhotoRelationshipDataAccessService StationToPhotoRelationshipDataAccessService
        { get; private set; }
        public IStationToRailwayRelationshipDataAccessService StationToRailwayRelationshipDataAccessService
        { get; private set; }
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
