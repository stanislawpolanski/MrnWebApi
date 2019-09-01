using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.Railway
{
    public interface IRailwayDataAccessService
    {
        Task<IEnumerable<RailwayDTO>> GetRailwaysByStationIdAsync(int stationId);
        Task<RailwayDTO> GetRailwayByIdAsync(int id);
    }
}
