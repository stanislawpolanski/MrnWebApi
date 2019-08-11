using MrnWebApi.DataAccess.Services.Geometry;
using MrnWebApi.DataAccess.Services.Photo;
using MrnWebApi.DataAccess.Services.Railway;
using MrnWebApi.DataAccess.Services.RailwayUnit;
using MrnWebApi.DataAccess.Services.Station;
using MrnWebApi.DataAccess.Services.StationToPhoto;

namespace MrnWebApi.DataAccess.ServicesFactory
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
