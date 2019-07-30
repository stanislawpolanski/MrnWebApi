using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<StationModel> GetAllBasicStations();
        Task<StationModel> GetDetailedStationByIdAsync(int id);
        void AddStation(StationModel inputStation);
        void DeleteStationById(int id);
        void UpdateStation(StationModel inputStation);
    }
}
