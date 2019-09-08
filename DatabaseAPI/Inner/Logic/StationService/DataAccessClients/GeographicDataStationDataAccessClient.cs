using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
{
    public class GeographicDataStationDataAccessClient : 
        IGeographicDataStationDataAccessClient
    {
        private IGeometryDataAccessService geometryDataAccessService;
        private IRailwayUnitDataAccessService railwayUnitDataAccessService;
        public GeographicDataStationDataAccessClient(
            IGeometryDataAccessService geometryDataAccessService,
            IRailwayUnitDataAccessService railwayUnitDataAccessService)
        {
            this.geometryDataAccessService = geometryDataAccessService;
            this.railwayUnitDataAccessService = railwayUnitDataAccessService;
        }

        public async Task FillStationWithGeographicDataAsync(StationDTO station)
        {
            station.SerialisedGeometry = await geometryDataAccessService
                .GetFirstGeometryByStationIdAsync(station.Id);
            station.RailwayUnit = await railwayUnitDataAccessService
                .GetRailwayUnitByStationAsync(station);
        }
    }
}
