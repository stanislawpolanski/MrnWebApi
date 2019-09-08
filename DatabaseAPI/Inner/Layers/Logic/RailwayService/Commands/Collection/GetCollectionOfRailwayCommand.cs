using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;

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
