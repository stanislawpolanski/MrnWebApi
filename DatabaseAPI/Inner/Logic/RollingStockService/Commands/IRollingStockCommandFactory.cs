using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single;
using System;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockCommandFactory
    {
        GetSingleRollingStockCommand<RollingStockDTO> GetGetRollingStockByIdCommand();
    }
}
