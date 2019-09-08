using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService
{
    public interface IStationLogicService
    {
        Task<IEnumerable<StationDTO>> GetAllBasicStationsAsync();
        Task<StationDTO> GetStationByIdAsync(int id);
        Task PostStationAsync(StationDTO inputStation);
        Task DeleteStationByIdAsync(int id);
        Task PutStationAsync(StationDTO inputStation);
    }
}
