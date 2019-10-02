using DatabaseAPI.Inner.Common.Command.Executor;
using DatabaseAPI.Inner.Common.Routing;
using DatabaseAPI.Inner.DataAccess.Services.Geometry;
using DatabaseAPI.Inner.DataAccess.Services.Owner;
using DatabaseAPI.Inner.DataAccess.Services.Photo;
using DatabaseAPI.Inner.DataAccess.Services.Railway;
using DatabaseAPI.Inner.DataAccess.Services.RailwayUnit;
using DatabaseAPI.Inner.DataAccess.Services.RollingStock;
using DatabaseAPI.Inner.DataAccess.Services.Station;
using DatabaseAPI.Inner.DataAccess.Services.StationToPhoto;
using DatabaseAPI.Inner.DataAccess.Services.StationToRailway;
using DatabaseAPI.Inner.DataAccess.Services.TypeOfAStation;
using DatabaseAPI.Inner.Logic.Owner;
using DatabaseAPI.Inner.Logic.RailwayService;
using DatabaseAPI.Inner.Logic.RailwayService.Commands.Factory;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;
using DatabaseAPI.Inner.Logic.RollingStockService;
using DatabaseAPI.Inner.Logic.RollingStockService.Clients;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands;
using DatabaseAPI.Inner.Logic.StationService;
using DatabaseAPI.Inner.Logic.StationService.Commands.Executor;
using DatabaseAPI.Inner.Logic.StationService.DataAccessClients;
using DatabaseAPI.Inner.Logic.TypeOfAStationService;
using GeoAPI.IO;
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
            RegisterLogicServicesHelpers(services);
            RegisterDataAccessServices(services);
        }

        private static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddTransient<
                IStationDataAccessService,
                DbStationDataAccessService>();
            services.AddTransient<
                ITypeOfAStationDataAccessService,
                DbTypeOfAStationDataAccessService>();
            services.AddTransient<
                IRailwayDataAccessService,
                DbRailwayDataAccessService>();
            services.AddTransient<
                IPhotoDataAccessService,
                DbPhotoDataAccessService>();
            services.AddTransient<
                IRailwayUnitDataAccessService,
                DbRailwayUnitDataAccessService>();
            services.AddTransient<
                IGeometryDataAccessService,
                DbGeometryDataAccessService>();
            services.AddTransient<
                IStationToPhotoRelationshipDataAccessService,
                DbStationToPhotoRelationshipDataAccessService>();
            services.AddTransient<
                IStationToRailwayRelationshipDataAccessService,
                DbStationToRailwayRelationshipDataAccessService>();
            services.AddTransient<
                IRollingStockDataAccessService,
                DbRollingStockDataAccessService>();
            services.AddTransient<
                IOwnerDataAccessService,
                DbOwnerDataAccessService>();
        }

        private static void RegisterLogicServices(IServiceCollection services)
        {
            services.AddTransient<IStationLogicService, StationLogicService>();
            services.AddTransient<ITypeOfAStationLogicService, TypeOfAStationLogicService>();
            services.AddTransient<IRailwayLogicService, RailwayLogicService>();
            services.AddTransient<IRollingStockLogicService, RollingStockLogicService>();
            services.AddTransient<IOwnerLogicService, OwnerLogicService>();
        }

        private static void RegisterLogicServicesHelpers(IServiceCollection services)
        {
            RegisterStationLogicHelpers(services);
            RegisterRailwayLogicHelpers(services);
            RegisterRollingStockLogicHelpers(services);
        }

        private static void RegisterRollingStockLogicHelpers(IServiceCollection services)
        {
            services.AddTransient<IRollingStockDataAccessClient, RollingStockDataAccessClient>();
            services.AddTransient<IRollingStockCommandFactory, RollingStockCommandFactory>();
        }

        private static void RegisterRailwayLogicHelpers(IServiceCollection services)
        {
            services.AddTransient<
                IRailwayDataEssentialsClient,
                RailwayDataEssentialsClient>();
            services.AddTransient<
                IRailwayDataStationsClient,
                RailwayDataStationsClient>();
            services.AddTransient<
                IRailwayLogicDataAccessClientsProvider,
                RailwayLogicDataAccessClientsProvider>();
            services.AddTransient<
                IRailwayCommandFactory,
                RailwayCommandFactory>();
        }

        private static void RegisterStationLogicHelpers(IServiceCollection services)
        {
            services.AddTransient<
                IEssentialDataStationDataAccessClient,
                EssentialDataStationDataAccessClient>();
            services.AddTransient<
                IGeographicDataStationDataAccessClient,
                GeographicDataStationDataAccessClient>();
            services.AddTransient<IStationCommandExecutor, StationCommandExecutor>();
        }

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddTransient<UriRoute, UriRoute>();
            services.AddTransient<ITextGeometryReader, WKTReader>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
        }
    }
}
