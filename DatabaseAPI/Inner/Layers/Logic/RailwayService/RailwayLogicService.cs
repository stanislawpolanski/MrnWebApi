using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DatabaseAPI.Inner.Common.Command.Executor;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService
{
    public class RailwayLogicService : IRailwayLogicService
    {
        private IRailwayLogicDataAccessClientsProvider clientsProvider;
        private ICommandExecutor executor;
        public RailwayLogicService(
            IRailwayLogicDataAccessClientsProvider clientsProvider,
            ICommandExecutor executor)
        {
            this.clientsProvider = clientsProvider;
            this.executor = executor;
        }
        public async Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RailwayDTO> GetRailwayById(int id)
        {
            RailwayDTO inputRailway = new RailwayDTO.Builder().WithId(id).Build();
            ISingleRailwayCommand command = new GetSingleRailwayCommand();
            RailwayDTO result = await ExecuteSingleRailwayCommand(inputRailway, command);
            if(result == null)
            {
                return null;
            }
            OrderStationsByKmPosts(result);
            return result;
        }

        private async Task<RailwayDTO> ExecuteSingleRailwayCommand(
            RailwayDTO inputRailway, 
            ISingleRailwayCommand command)
        {
            command.SetRailway(inputRailway);
            clientsProvider.InjectClients(command);
            await executor.ExecuteCommandAsync(command);
            RailwayDTO result = command.GetExecutionResult();
            return result;
        }

        private static void OrderStationsByKmPosts(RailwayDTO railway)
        {
            railway.StationsKmPosts = railway
                .StationsKmPosts
                .OrderBy(station => station.CentreKmPost);
        }
    }
}
