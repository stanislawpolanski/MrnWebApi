using DatabaseAPI.Inner.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockDataAccessClient
    {
        Task<RollingStockDTO> GetRollingStockById(int id);
        Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync();
    }
}
