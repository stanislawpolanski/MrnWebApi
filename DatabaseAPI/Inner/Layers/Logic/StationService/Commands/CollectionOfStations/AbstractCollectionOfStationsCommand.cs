using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;

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
