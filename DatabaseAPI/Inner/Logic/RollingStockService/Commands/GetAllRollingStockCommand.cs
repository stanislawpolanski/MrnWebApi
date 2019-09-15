using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public class GetAllRollingStockCommand<T> : AbstractRollingStockCommand<T>
        where T : List<RollingStockDTO>
    {
        public override async Task ExecuteAsync()
        {
            result = await rollingStockClient.GetAllRollingStockAsync() as T;
        }
    }
}
