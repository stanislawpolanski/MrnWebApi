using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.Command.Executor
{
    public class CommandExecutor : ICommandExecutor
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            await command.ExecuteAsync();
        }
    }
}
