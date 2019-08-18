using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.ServicesFactory;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService.Inner
{
    public abstract class AbstractStationLogicProcessor
    {
        protected StationDTO station;
        protected readonly IEssentialDataStationLogicService essentialDataService;
        protected readonly IGeographicDataStationLogicService geographicDataService;

        protected bool ProcessGeographicData;
        public AbstractStationLogicProcessor(
            IEssentialDataStationLogicService essentialDataService,
            IGeographicDataStationLogicService geographicDataService)
        {
            this.essentialDataService = essentialDataService;
            this.geographicDataService = geographicDataService;
        }

        public AbstractStationLogicProcessor ProcessStation(StationDTO station)
        {
            this.station = station;
            return this;
        }
        public AbstractStationLogicProcessor WithGeographicData()
        {
            this.ProcessGeographicData = true;
            return this;
        }

        public abstract Task<StationDTO> GetStationAsync();
    }
}
