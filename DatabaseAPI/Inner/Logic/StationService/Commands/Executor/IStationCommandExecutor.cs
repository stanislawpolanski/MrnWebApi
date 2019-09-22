using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Executor
{
    public interface IStationCommandExecutor
    {
        Task ExecuteCommand(IStationCommand command);
    }
}
