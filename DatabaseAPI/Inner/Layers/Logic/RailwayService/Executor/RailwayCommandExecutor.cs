using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Executor
{
    public class RailwayCommandExecutor : IRailwayCommandExecutor
    {
        public async Task ExecuteCommand(IRailwayCommand command)
        {
            await command.ExecuteAsync();
        }
    }
}
