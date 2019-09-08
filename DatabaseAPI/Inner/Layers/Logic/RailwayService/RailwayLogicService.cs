using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.Command.Executor;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Factory;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Set;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService
{
    public class RailwayLogicService : IRailwayLogicService
    {
        private IRailwayCommandFactory factory;
        private ICommandExecutor executor;
        public RailwayLogicService(
            IRailwayCommandFactory factory,
            ICommandExecutor executor)
        {
            this.factory = factory;
            this.executor = executor;
        }
        public async Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync()
        {
            ICollectionOfRailwayCommand command = factory.GetGetSetOfRailwaysCommand();
            await executor.ExecuteCommandAsync(command);
            return command.GetExecutionResult();
        }

        public async Task<RailwayDTO> GetRailwayById(int id)
        {
            RailwayDTO inputRailway = new RailwayDTO.Builder().WithId(id).Build();
            ISingleRailwayCommand command = factory.GetGetSingleRailwayCommand();
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
            await executor.ExecuteCommandAsync(command);
            return command.GetExecutionResult();
        }

        private static void OrderStationsByKmPosts(RailwayDTO railway)
        {
            railway.StationsKmPosts = railway
                .StationsKmPosts
                .OrderBy(station => station.CentreKmPost);
        }
    }
}
