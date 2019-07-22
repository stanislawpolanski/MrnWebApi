using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<StationModel> GetAllBasicStations();
        StationModel GetDetailedStationById(int id);
        void AddStation(StationModel inputStation);
        void DeleteStationById(int id);
        void UpdateStation(StationModel inputStation);
    }
}
