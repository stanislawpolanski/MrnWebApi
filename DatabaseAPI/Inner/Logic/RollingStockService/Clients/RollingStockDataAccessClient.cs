using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.RollingStock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Clients
{
    public class RollingStockDataAccessClient : IRollingStockDataAccessClient
    {
        private IRollingStockDataAccessService service;
        public RollingStockDataAccessClient(IRollingStockDataAccessService service)
        {
            this.service = service;
        }

        public async Task<RollingStockDTO> DeleteRollingStock(RollingStockDTO rollingStockDTO)
        {
            return await service.DeleteRollingStockAsync(rollingStockDTO);
        }

        public async Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync()
        {
            return await service.GetAllRollingStockAsync();
        }

        public async Task<RollingStockDTO> GetRollingStockByIdAsync(int id)
        {
            return await service.GetRollingStockByIdAsync(id);
        }

        public async Task<RollingStockDTO> PostRollingStockAsync(
            RollingStockDTO subject)
        {
            return await service.PostRollingStockAsync(subject);
        }

        public async Task<RollingStockDTO> PutRollingStockAsync(
            RollingStockDTO rollingStockDTO)
        {
            return await service.PutRollingStockAsync(rollingStockDTO);
        }
    }
}
