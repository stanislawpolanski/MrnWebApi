using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.RollingStock
{
    public interface IRollingStockDataAccessService
    {
        Task<RollingStockDTO> GetRollingStockByIdAsync(int id);
        Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync();
        Task<RollingStockDTO> DeleteRollingStockAsync(RollingStockDTO subject);
        Task<RollingStockDTO> PostRollingStockAsync(RollingStockDTO subject);
    }
}
