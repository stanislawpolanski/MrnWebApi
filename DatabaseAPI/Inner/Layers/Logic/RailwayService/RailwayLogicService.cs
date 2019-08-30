using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Executor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            ISingleRailwayCommand command = new GetSingleRailwayCommand();
            RailwayDTO railway = new RailwayDTO.Builder().WithId(id).Build();
            command.SetRailway(railway);
            clientsProvider.InjectClients(command);
            IRailwayCommandExecutor executor = new RailwayCommandExecutor();
            await executor.ExecuteCommand(command);
            return railway;
        }
    }
}
