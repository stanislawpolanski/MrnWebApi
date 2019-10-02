using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands
{
    public interface IRailwayCommand : ICommand
    {
        void SetEssentialsClient(IRailwayDataEssentialsClient client);
    }
}
