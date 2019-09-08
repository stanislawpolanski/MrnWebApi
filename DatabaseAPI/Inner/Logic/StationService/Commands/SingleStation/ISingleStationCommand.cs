using DatabaseAPI.Common.DTOs;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    interface ISingleStationCommand : IStationCommand
    {
        void SetStation(StationDTO station);
    }
}
