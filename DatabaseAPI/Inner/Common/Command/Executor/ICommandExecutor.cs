using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.Command.Executor
{
    public interface ICommandExecutor
    {
        Task ExecuteCommandAsync(ICommand command);
    }
}
