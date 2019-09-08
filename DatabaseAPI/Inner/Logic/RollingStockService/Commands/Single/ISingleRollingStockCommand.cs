using DatabaseAPI.Inner.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface ISingleRollingStockCommand : IRollingStockCommand
    {
        void SetQueryItem(RollingStockDTO item);
        RollingStockDTO GetExecutionResult();
    }
}
