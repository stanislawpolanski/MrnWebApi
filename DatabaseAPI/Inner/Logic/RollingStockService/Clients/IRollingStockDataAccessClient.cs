using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockDataAccessClient
    {
        Task<RollingStockDTO> GetRollingStockByIdAsync(int id);
        Task<RollingStockDTO> PostRollingStockAsync(RollingStockDTO subject);
        Task<RollingStockDTO> DeleteRollingStock(RollingStockDTO rollingStockDTO);
        Task<RollingStockDTO> PutRollingStockAsync(RollingStockDTO rollingStockDTO);
        Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync();
    }
}
