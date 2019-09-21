using System.Collections;
using System.Collections.Generic;
using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Common.DTOs;
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

        public GetSingleRollingStockCommand<RollingStockDTO> 
            ProduceGetRollingStockByIdCommand()
        {
            var command = new GetSingleRollingStockCommand<RollingStockDTO>();
            command.SetRollingStockDataAccessClient(rollingStockClient);
            return command;
        }

        public AbstractCommandWithSubject<List<RollingStockDTO>> 
            ProduceGetAllRollingStockCommand()
        {
            var command = new GetAllRollingStockCommand<List<RollingStockDTO>>();
            command.SetRollingStockDataAccessClient(rollingStockClient);
            return command;
        }

        public AbstractCommandWithSubject<RollingStockDTO> ProducePostRollingStockCommand()
        {
            throw new System.NotImplementedException();
        }

        public AbstractCommandWithSubject<RollingStockDTO> ProduceDeleteRollingStockCommand()
        {
            var command = new DeleteRollingStockCommand<RollingStockDTO>();
            command.SetRollingStockDataAccessClient(rollingStockClient);
            return command;
        }
    }
}
