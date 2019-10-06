using DatabaseAPI.Inner.Logic.RailwayService.Commands.Collection;
using DatabaseAPI.Inner.Logic.RailwayService.Commands.Single;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Factory
{
    public interface IRailwayCommandFactory
    {
        ISingleRailwayCommand GetGetSingleRailwayCommand();
        ICollectionOfRailwayCommand GetGetSetOfRailwaysCommand();
    }
}
