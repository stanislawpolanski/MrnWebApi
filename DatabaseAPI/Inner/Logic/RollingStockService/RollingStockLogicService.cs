using DatabaseAPI.Inner.Common.Command.Executor;
using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService
{
    public class RollingStockLogicService : IRollingStockLogicService
    {
        private IRollingStockCommandFactory factory;
        private ICommandExecutor executor;

        public RollingStockLogicService(
            IRollingStockCommandFactory factory,
            ICommandExecutor executor)
        {
            this.factory = factory;
            this.executor = executor;
        }
        public async Task<RollingStockDTO> GetRollingStockByIdAsync(int id)
        {
            RollingStockDTO dto = new RollingStockDTO.Builder().WithId(id).Build();
            AbstractRollingStockCommand<RollingStockDTO> command = factory.GetGetRollingStockByIdCommand();
            command.SetExecutionSubject(dto);
            await executor.ExecuteCommandAsync(command);
            return command.GetResult();
        }
    }
}
