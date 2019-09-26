using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockCommandFactory
    {
        GetSingleRollingStockCommand<RollingStockDTO> ProduceGetRollingStockByIdCommand();
        AbstractCommandWithSubject<List<RollingStockDTO>> ProduceGetAllRollingStockCommand();
        AbstractCommandWithSubject<RollingStockDTO> ProducePostRollingStockCommand();
        AbstractCommandWithSubject<RollingStockDTO> ProduceDeleteRollingStockCommand();
        AbstractCommandWithSubject<RollingStockDTO> ProducePutRollingStockCommand();
    }
}
