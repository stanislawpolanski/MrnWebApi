using DatabaseAPI.Inner.Common.Command.Executor;
using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands;
using System.Collections.Generic;
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
            AbstractRollingStockCommand<RollingStockDTO> command = factory.ProduceGetRollingStockByIdCommand();
            command.SetExecutionSubject(dto);
            await executor.ExecuteCommandAsync(command);
            return command.GetResult();
        }

        public async Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync()
        {
            var command = factory.ProduceGetAllRollingStockCommand();
            await executor.ExecuteCommandAsync(command);
            return command.GetResult();
        }

        public async Task<RollingStockDTO> PostRollingStockAsync(RollingStockDTO inputDto)
        {
            var command = factory.ProducePostRollingStockCommand();
            command.SetExecutionSubject(inputDto);
            await executor.ExecuteCommandAsync(command);
            return command.GetResult();
        }

        public async Task<bool> DeleteRollingStockByIdAsync(int id)
        {
            var dto = new RollingStockDTO.Builder().WithId(id).Build();
            var command = factory.ProduceDeleteRollingStockCommand();
            command.SetExecutionSubject(dto);
            await executor.ExecuteCommandAsync(command);
            var result = command.GetResult();
            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
