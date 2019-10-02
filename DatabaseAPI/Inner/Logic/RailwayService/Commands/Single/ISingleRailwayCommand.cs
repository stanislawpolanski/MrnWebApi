using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Single
{
    public interface ISingleRailwayCommand : IRailwayCommand
    {
        void SetRailway(RailwayDTO railway);
        void SetStationsClient(IRailwayDataStationsClient client);
        RailwayDTO GetExecutionResult();
    }
}