using DatabaseAPI.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        Task<RailwayUnitDTO> GetRailwayUnitByStationAsync(StationDTO station);
    }
}
