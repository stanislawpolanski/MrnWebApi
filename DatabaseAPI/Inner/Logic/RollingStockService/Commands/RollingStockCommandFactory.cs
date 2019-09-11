using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public class RollingStockCommandFactory : IRollingStockCommandFactory
    {
        private IRollingStockDataAccessClient client;

        public RollingStockCommandFactory(IRollingStockDataAccessClient client)
        {
            this.client = client;
        }
        public GetSingleRollingStockCommand<RollingStockDTO> GetGetRollingStockByIdCommand()
        {
            var command = new GetSingleRollingStockCommand<RollingStockDTO>();
            command.SetDataAccessClient(client);
            return command;
        }
    }
}
