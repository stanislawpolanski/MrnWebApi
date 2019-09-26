using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService
{
    public interface IRollingStockLogicService
    {
        Task<RollingStockDTO> GetRollingStockByIdAsync(int id);
        Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync();
        Task<RollingStockDTO> PostRollingStockAsync(RollingStockDTO inputDto);
        Task<bool> DeleteRollingStockByIdAsync(int id);
        Task<bool> PutRollingStockAsync(RollingStockDTO dto);
    }
}
