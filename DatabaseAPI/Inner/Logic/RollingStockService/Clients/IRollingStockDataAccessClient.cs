using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockDataAccessClient
    {
        Task<RollingStockDTO> GetRollingStockById(int id);
        Task<RollingStockDTO> PostRollingStock(RollingStockDTO subject);
        Task<RollingStockDTO> DeleteRollingStock(RollingStockDTO rollingStockDTO);
        Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync();
    }
}
