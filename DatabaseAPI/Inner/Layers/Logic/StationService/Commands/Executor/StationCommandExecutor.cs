using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Executor
{
    public class StationCommandExecutor : IStationCommandExecutor
    {
        private IEssentialDataStationLogicService essentialsService;
        private IGeographicDataStationLogicService geographicsService;
        public StationCommandExecutor(
            IEssentialDataStationLogicService essentialsService, 
            IGeographicDataStationLogicService geographicsService)
        {
            this.essentialsService = essentialsService;
            this.geographicsService = geographicsService;
        }
        public async Task ExecuteCommand(IStationCommand command)
        {
            command.SetServices(essentialsService, geographicsService);
            await command.ExecuteAsync();
        }
    }
}
