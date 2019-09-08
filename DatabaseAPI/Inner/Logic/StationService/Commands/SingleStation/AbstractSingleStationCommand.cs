using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public abstract class AbstractSingleStationCommand : ISingleStationCommand
    {
        protected StationDTO station;
        protected IEssentialDataStationDataAccessClient essentialsService;
        protected IGeographicDataStationDataAccessClient geographicsService;
        public abstract Task ExecuteAsync();

        public void SetDataAcessClients(IEssentialDataStationDataAccessClient essentialsService, IGeographicDataStationDataAccessClient geographicsService)
        {
            this.essentialsService = essentialsService;
            this.geographicsService = geographicsService;
        }

        public void SetStation(StationDTO station)
        {
            this.station = station;
        }
    }
}
