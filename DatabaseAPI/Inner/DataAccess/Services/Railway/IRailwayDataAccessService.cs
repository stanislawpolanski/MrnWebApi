using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Railway
{
    public interface IRailwayDataAccessService
    {
        Task<IEnumerable<RailwayDTO>> GetRailwaysByStationIdAsync(int stationId);
        Task<RailwayDTO> GetRailwayByIdAsync(int id);
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
    }
}
