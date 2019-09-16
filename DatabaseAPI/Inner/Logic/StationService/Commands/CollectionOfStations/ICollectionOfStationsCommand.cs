using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public interface ICollectionOfStationsCommand : IStationCommand
    {
        void SetStationsCollection(List<StationDTO> stations);
    }
}
