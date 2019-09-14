using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.RollingStock;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public class RollingStockDataAccessClient : IRollingStockDataAccessClient
    {
        private IRollingStockDataAccessService service;
        public RollingStockDataAccessClient(IRollingStockDataAccessService service)
        {
            this.service = service;
        }
        public async Task<RollingStockDTO> GetRollingStockById(int id)
        {
            return await service.GetRollingStockByIdAsync(id);
        }
    }
}
