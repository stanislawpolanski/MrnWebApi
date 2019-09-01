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
            RailwayDTO railway = new RailwayDTO.Builder().WithId(id).Build();
            await FillRailway(railway);
            OrderStationsByKmPosts(railway);
            return railway;
        }

        private static void OrderStationsByKmPosts(RailwayDTO railway)
        {
            railway.StationsKmPosts = railway
                .StationsKmPosts
                .OrderBy(station => station.CentreKmPost);
        }

        private async Task FillRailway(RailwayDTO railway)
        {
            ISingleRailwayCommand command = new GetSingleRailwayCommand();
            command.SetRailway(railway);
            clientsProvider.InjectClients(command);
            IRailwayCommandExecutor executor = new RailwayCommandExecutor();
            await executor.ExecuteCommand(command);
        }
    }
}
