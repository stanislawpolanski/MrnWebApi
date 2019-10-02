using DatabaseAPI.Inner.Common.DTOs;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.SingleStation
{
    interface ISingleStationCommand : IStationCommand
    {
        void SetStation(StationDTO station);
    }
}
