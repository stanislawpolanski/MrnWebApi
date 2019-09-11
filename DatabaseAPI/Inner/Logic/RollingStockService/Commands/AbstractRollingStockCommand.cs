using DatabaseAPI.Inner.Common.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public abstract class AbstractRollingStockCommand<T> : AbstractCommandWithSubject<T>
    {
        protected IRollingStockDataAccessClient client;
        public void SetDataAccessClient(IRollingStockDataAccessClient client)
        {
            this.client = client;
        }
    }
}
