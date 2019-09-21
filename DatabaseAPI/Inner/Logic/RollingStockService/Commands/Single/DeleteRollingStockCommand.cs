using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single
{
    public class DeleteRollingStockCommand<T> : AbstractRollingStockCommand<T>
        where T : RollingStockDTO
    {
        public async override Task ExecuteAsync()
        {
            result = await rollingStockClient
                .DeleteRollingStock(subject as RollingStockDTO) as T;
        }
    }
}
