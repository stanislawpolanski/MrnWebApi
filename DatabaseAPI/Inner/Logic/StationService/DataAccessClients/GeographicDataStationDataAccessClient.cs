using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Geometry;
using DatabaseAPI.Inner.DataAccess.Services.RailwayUnit;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.DataAccessClients
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
