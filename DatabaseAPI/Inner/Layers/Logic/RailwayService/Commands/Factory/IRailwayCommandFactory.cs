using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Set;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Factory
{
    public interface IRailwayCommandFactory
    {
        ISingleRailwayCommand GetGetSingleRailwayCommand();
        ISetOfRailwayCommand GetGetSetOfRailwaysCommand();
    }
}
