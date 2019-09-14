using DatabaseAPI.Inner.Common.Command;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public abstract class AbstractRollingStockCommand<T> : AbstractCommandWithSubject<T>
    {
        protected IRollingStockDataAccessClient rollingStockClient;
        public void SetRollingStockDataAccessClient(IRollingStockDataAccessClient client)
        {
            this.rollingStockClient = client;
        }
    }
}
