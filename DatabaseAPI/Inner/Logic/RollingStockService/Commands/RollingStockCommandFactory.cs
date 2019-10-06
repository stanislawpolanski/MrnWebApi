using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Clients;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single;
using System.Collections.Generic;

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
            return ProduceCommandWithService(new PostRollingStockCommand<RollingStockDTO>());
        }

        public AbstractCommandWithSubject<RollingStockDTO> ProduceDeleteRollingStockCommand()
        {
            return ProduceCommandWithService(new DeleteRollingStockCommand<RollingStockDTO>());
        }

        public AbstractCommandWithSubject<RollingStockDTO> ProducePutRollingStockCommand()
        {
            return ProduceCommandWithService(new PutRollingStockCommand<RollingStockDTO>());
        }

        private AbstractCommandWithSubject<RollingStockDTO> ProduceCommandWithService(
            AbstractRollingStockCommand<RollingStockDTO> command)
        {
            command.SetRollingStockDataAccessClient(rollingStockClient);
            return command;
        }
    }
}
