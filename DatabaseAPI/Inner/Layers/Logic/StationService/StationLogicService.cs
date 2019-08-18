using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.CollectionOfStations;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Executor;
using DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Implementations;
using System;
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
            throw new NotImplementedException();
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            StationDTO stationModel = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            throw new NotImplementedException();
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
            //todo to be refactored to dto builder
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
            throw new NotImplementedException();
        }
    }
}
