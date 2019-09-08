namespace DatabaseAPI.Inner.Logic.RollingStockService.Commands
{
    public interface IRollingStockCommandFactory
    {
        ISingleRollingStockCommand GetGetRollingStockByIdCommand();
    }
}
