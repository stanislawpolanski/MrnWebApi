using MrnWebApi.Common.DTOs;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        Task<RailwayUnitDTO> GetRailwayUnitByStationAsync(StationDTO station);
    }
}
