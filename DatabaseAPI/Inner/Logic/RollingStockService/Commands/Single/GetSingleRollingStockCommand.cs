using DatabaseAPI.Inner.Common.DTOs;
using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single
{
    public class GetSingleRollingStockCommand<T> : AbstractRollingStockCommand<T>
        where T : RollingStockDTO
    {
        public override async Task ExecuteAsync()
        {
            result = await client.GetRollingStockById(subject.Id) as T;
        }
    }
}
