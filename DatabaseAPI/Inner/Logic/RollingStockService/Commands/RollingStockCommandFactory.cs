﻿using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public class RollingStockCommandFactory : IRollingStockCommandFactory
    {
        private IRollingStockDataAccessClient rollingStockClient;

        public RollingStockCommandFactory(
            IRollingStockDataAccessClient rollingStockClient)
        {
            this.rollingStockClient = rollingStockClient;
        }
        public GetSingleRollingStockCommand<RollingStockDTO> GetGetRollingStockByIdCommand()
        {
            var command = new GetSingleRollingStockCommand<RollingStockDTO>();
            command.SetRollingStockDataAccessClient(rollingStockClient);
            return command;
        }
    }
}
