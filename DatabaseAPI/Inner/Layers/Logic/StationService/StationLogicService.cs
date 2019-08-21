using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.CollectionOfStations;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Executor;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Implementations;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.SingleStation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private IStationCommandExecutor commandExecutor;
        public StationLogicService(IStationCommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public async Task PostStationAsync(StationDTO inputStation)
        {
            ISingleStationCommand command = new PostSingleStationCommand();
            command.SetStation(inputStation);
            await commandExecutor.ExecuteCommand(command);
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            StationDTO station = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            ISingleStationCommand command = new DeleteSingleStationCommand();
            command.SetStation(station);
            await commandExecutor.ExecuteCommand(command);
        }

        public async Task<IEnumerable<StationDTO>> GetAllBasicStationsAsync()
        {
            List<StationDTO> stations = new List<StationDTO>();
            ICollectionOfStationsCommand command = 
                new GetCollectionOfStationsCommand();
            command.SetStationsCollection(stations);
            await commandExecutor.ExecuteCommand(command);
            return stations.OrderBy(station => station.Name);
        }

        public async Task<StationDTO> GetStationByIdAsync(int inputId)
        {
            StationDTO station = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            ISingleStationCommand command = new GetSingleStationCommand();
            command.SetStation(station);
            await commandExecutor.ExecuteCommand(command);
            return station;
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            ISingleStationCommand command = new PutSingleStationCommand();
            command.SetStation(inputStation);
            await commandExecutor.ExecuteCommand(command);
        }
    }
}
