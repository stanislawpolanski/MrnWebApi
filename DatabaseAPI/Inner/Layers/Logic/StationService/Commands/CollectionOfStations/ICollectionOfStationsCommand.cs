using DatabaseAPI.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public interface ICollectionOfStationsCommand : IStationCommand
    {
        void SetStationsCollection(List<StationDTO> stations);
    }
}
