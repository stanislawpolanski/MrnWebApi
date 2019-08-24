using DatabaseAPI.Common.Routing;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.Services.StationToPhoto;
using DatabaseAPI.DataAccess.Services.StationToRailway;
using DatabaseAPI.DataAccess.Services.TypeOfAStation;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Executor;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using DatabaseAPI.Logic.StationService;
using DatabaseAPI.Logic.TypeOfAStationService;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetTopologySuite.IO;

namespace DatabaseAPI
{
    public static class ApiServicesRegistrator
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterCommonServices(services);
            RegisterLogicServices(services);
            RegisterDataAccessServices(services);
        }

        private static void RegisterDataAccessServices(IServiceCollection services)
        {


            services.AddTransient<IStationDataAccessService, 
                DbStationDataAccessService>();
            services.AddTransient<ITypeOfAStationDataAccessService, 
                DbTypeOfAStationDataAccessService>();
            services.AddTransient<IRailwayDataAccessService, 
                DbRailwayDataAccessService>();
            services.AddTransient<IPhotoDataAccessService, 
                DbPhotoDataAccessService>();
            services.AddTransient<IRailwayUnitDataAccessService, 
                DbRailwayUnitDataAccessService>();
            services.AddTransient<IGeometryDataAccessService, 
                DbGeometryDataAccessService>();
            services.AddTransient<IStationToPhotoRelationshipDataAccessService, 
                DbStationToPhotoRelationshipDataAccessService>();
            services.AddTransient<IStationToRailwayRelationshipDataAccessService, 
                DbStationToRailwayRelationshipDataAccessService>();
        }

        private static void RegisterLogicServices(IServiceCollection services)
        {
            services.AddTransient<IStationLogicService, StationLogicService>();
            services.AddTransient<IStationCommandExecutor, StationCommandExecutor>();
            services.AddTransient<ITypeOfAStationLogicService, 
                TypeOfAStationLogicService>();
            services.AddTransient<IEssentialDataStationDataAccessClient, 
                EssentialDataStationDataAccessClient>();
            services.AddTransient<IGeographicDataStationDataAccessClient, 
                GeographicDataStationDataAccessClient>();
            
        }

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddTransient<UriRoute, UriRoute>();
            services.AddTransient<ITextGeometryReader, WKTReader>();
        }
    }
}
