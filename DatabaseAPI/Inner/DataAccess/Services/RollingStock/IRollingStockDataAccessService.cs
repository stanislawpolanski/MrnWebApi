using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Inner.Common.DTOs;

namespace DatabaseAPI.Inner.DataAccess.Services.RollingStock
{
    public interface IRollingStockDataAccessService
    {
        Task<RollingStockDTO> GetRollingStockByIdAsync(int id);
    }
}
