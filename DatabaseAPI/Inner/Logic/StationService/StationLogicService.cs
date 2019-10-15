using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Station;
using DatabaseAPI.Inner.Logic.StationService.Commands.CollectionOfStations;
using DatabaseAPI.Inner.Logic.StationService.Commands.Executor;
using DatabaseAPI.Inner.Logic.StationService.Commands.SingleStation;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private IStationCommandExecutor commandExecutor;
        private IStationDataAccessService service;

        public StationLogicService(
            IStationCommandExecutor commandExecutor,
            IStationDataAccessService service
            )
        {
            this.commandExecutor = commandExecutor;
            this.service = service;
        }

        public async Task PostStationAsync(StationDTO inputStation)
        {
            ISingleStationCommand command = new PostSingleStationCommand();
            await RunSingleStationCommand(inputStation, command);
        }

        private async Task RunSingleStationCommand(StationDTO inputStation,
            ISingleStationCommand command)
        {
            command.SetStation(inputStation);
            await commandExecutor.ExecuteCommand(command);
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            StationDTO station = new StationDTO
                .Builder()
                .WithId(inputId)
                .Build();
            ISingleStationCommand command = new DeleteSingleStationCommand();
            await RunSingleStationCommand(station, command);
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
                .WithId(inputId)
                .Build();
            ISingleStationCommand command = new GetSingleStationCommand();
            await RunSingleStationCommand(station, command);
            return station;
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            ISingleStationCommand command = new PutSingleStationCommand();
            await RunSingleStationCommand(inputStation, command);
        }

        public async Task<IEnumerable<StationOnARailwayDTO>> GetStationsByRailwayIdAsync(
            int railwayId)
        {
            return await service.GetStationsByRailwayIdAsync(railwayId);
        }
    }
}
