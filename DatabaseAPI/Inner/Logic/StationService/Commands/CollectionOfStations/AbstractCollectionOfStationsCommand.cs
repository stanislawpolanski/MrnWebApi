using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.StationService.DataAccessClients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.CollectionOfStations
{
    public abstract class AbstractCollectionOfStationsCommand : ICollectionOfStationsCommand
    {
        protected IEssentialDataStationDataAccessClient essentialsService;
        protected List<StationDTO> collection;
        public abstract Task ExecuteAsync();

        public void SetDataAcessClients(
            IEssentialDataStationDataAccessClient essentialsService, 
            IGeographicDataStationDataAccessClient geographicsService)
        {
            this.essentialsService = essentialsService;
        }

        public void SetStationsCollection(List<StationDTO> stations)
        {
            this.collection = stations;
        }
    }
}
