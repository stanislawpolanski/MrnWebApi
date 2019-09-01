using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single
{
    public interface ISingleRailwayCommand : IRailwayCommand
    {
        void SetRailway(RailwayDTO railway);
        void SetStationsClient(IRailwayDataStationsClient client);
        RailwayDTO GetExecutionResult();
    }
}