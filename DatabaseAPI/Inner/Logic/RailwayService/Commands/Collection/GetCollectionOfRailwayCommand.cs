using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Collection
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
