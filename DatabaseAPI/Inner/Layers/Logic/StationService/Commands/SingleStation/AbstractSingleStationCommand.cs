using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public abstract class AbstractSingleStationCommand : ISingleStationCommand
    {
        protected StationDTO station;
        protected IEssentialDataStationLogicService essentialsService;
        protected IGeographicDataStationLogicService geographicsService;
        public abstract Task ExecuteAsync();

        public void SetServices(IEssentialDataStationLogicService essentialsService, IGeographicDataStationLogicService geographicsService)
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
