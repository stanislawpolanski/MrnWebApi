using DatabaseAPI.Inner.Logic.StationService.DataAccessClients;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.Executor
{
    public class StationCommandExecutor : IStationCommandExecutor
    {
        private IEssentialDataStationDataAccessClient essentialsService;
        private IGeographicDataStationDataAccessClient geographicsService;
        public StationCommandExecutor(
            IEssentialDataStationDataAccessClient essentialsService,
            IGeographicDataStationDataAccessClient geographicsService)
        {
            this.essentialsService = essentialsService;
            this.geographicsService = geographicsService;
        }
        public async Task ExecuteCommand(IStationCommand command)
        {
            command.SetDataAcessClients(essentialsService, geographicsService);
            await command.ExecuteAsync();
        }
    }
}
