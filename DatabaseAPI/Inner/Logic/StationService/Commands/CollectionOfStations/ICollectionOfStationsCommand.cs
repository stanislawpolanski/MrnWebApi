using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.CollectionOfStations
{
    public interface ICollectionOfStationsCommand : IStationCommand
    {
        void SetStationsCollection(List<StationDTO> stations);
    }
}
