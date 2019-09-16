using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands
{
    public interface IRailwayCommand : ICommand
    {
        void SetEssentialsClient(IRailwayDataEssentialsClient client);
    }
}
