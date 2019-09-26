using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands.Single
{
    public class GetSingleRollingStockCommand<T> : AbstractRollingStockCommand<T>
        where T : RollingStockDTO
    {
        public override async Task ExecuteAsync()
        {
            result = await rollingStockClient.GetRollingStockByIdAsync(subject.Id) as T;
        }
    }
}
