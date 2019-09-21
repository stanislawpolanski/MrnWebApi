using DatabaseAPI.Inner.Common.DTOs;
using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single
{
    public class PostRollingStockCommand<T> : AbstractRollingStockCommand<T>
        where T : RollingStockDTO
    {
        public async override Task ExecuteAsync()
        {
            result = await rollingStockClient
                .PostRollingStock(subject as RollingStockDTO) as T;
        }
    }
}
