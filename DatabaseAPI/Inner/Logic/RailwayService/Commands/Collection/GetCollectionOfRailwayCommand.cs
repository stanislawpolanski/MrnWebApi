using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Set
{
    public class GetCollectionOfRailwayCommand : ICollectionOfRailwayCommand
    {
        private IRailwayDataEssentialsClient client;
        private IEnumerable<RailwayDTO> executionResult;

        public async Task ExecuteAsync()
        {
            this.executionResult = await client.GetAllRailwaysAsync();
        }

        public IEnumerable<RailwayDTO> GetExecutionResult()
        {
            return this.executionResult;
        }

        public void SetEssentialsClient(IRailwayDataEssentialsClient client)
        {
            this.client = client;
        }
    }
}
