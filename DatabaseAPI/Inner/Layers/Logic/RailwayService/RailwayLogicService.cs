using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Executor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService
{
    public class RailwayLogicService : IRailwayLogicService
    {
        private IRailwayLogicDataAccessClientsProvider clientsProvider;
        public RailwayLogicService(IRailwayLogicDataAccessClientsProvider clientsProvider)
        {
            this.clientsProvider = clientsProvider;
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
            IRailwayCommandExecutor executor = new RailwayCommandExecutor();
            await executor.ExecuteCommand(command);
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
