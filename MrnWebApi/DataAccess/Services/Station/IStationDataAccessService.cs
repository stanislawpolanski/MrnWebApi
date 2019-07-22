using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        ICollection<StationModel> GetBasicStations();
        StationModel GetDetailedStation(int id);
        int AddStation(StationModel inputStation);
        void DeleteStationById(int id);
        void UpdateStation(StationModel station);
    }
}
