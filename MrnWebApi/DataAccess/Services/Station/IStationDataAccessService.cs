using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        ICollection<StationModel> GetBasicStations();
        Task<StationModel> GetDetailedStationAsync(int id);
        int AddStation(StationModel inputStation);
        void DeleteStationById(int id);
        void UpdateStation(StationModel station);
    }
}
