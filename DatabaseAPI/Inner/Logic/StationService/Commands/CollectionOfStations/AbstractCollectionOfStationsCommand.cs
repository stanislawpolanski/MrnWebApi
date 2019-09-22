using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public abstract class AbstractCollectionOfStationsCommand : ICollectionOfStationsCommand
    {
        protected IEssentialDataStationDataAccessClient essentialsService;
        protected List<StationDTO> collection;
        public abstract Task ExecuteAsync();

        public void SetDataAcessClients(IEssentialDataStationDataAccessClient essentialsService, IGeographicDataStationDataAccessClient geographicsService)
        {
            this.essentialsService = essentialsService;
        }

        public void SetStationsCollection(List<StationDTO> stations)
        {
            this.collection = stations;
        }
    }
}
