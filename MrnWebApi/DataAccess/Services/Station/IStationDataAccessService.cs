using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        Task<IEnumerable<StationModel>> GetBasicStationsAsync();
        Task<StationModel> GetDetailedStationAsync(int id);
        Task AddStationAsync(StationModel inputStation);
        Task DeleteStationByIdAsync(int id);
        Task UpdateStationAsync(StationModel station);
    }
}
