using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        Task<RailwayUnitDTO> GetRailwayUnitByStationAsync(StationDTO station);
    }
}
