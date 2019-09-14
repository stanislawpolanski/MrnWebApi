using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService
{
    public interface IRollingStockLogicService
    {
        Task<RollingStockDTO> GetRollingStockByIdAsync(int id);
    }
}
