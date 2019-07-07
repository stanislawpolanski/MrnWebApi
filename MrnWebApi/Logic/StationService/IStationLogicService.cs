using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<StationModel> GetBasicStations();
        StationModel GetDetailedStation(int id);
        void AddStation(StationModel inputStation);
    }
}
