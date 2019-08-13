using MrnWebApi.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        Task<IEnumerable<StationDTO>> GetBasicStationsAsync();
        Task<StationDTO> GetDetailedStationAsync(int id);
        Task PostStationAsync(StationDTO inputStation);
        Task DeleteStationByIdAsync(int id);
        Task PutStationAsync(StationDTO station);
    }
}
