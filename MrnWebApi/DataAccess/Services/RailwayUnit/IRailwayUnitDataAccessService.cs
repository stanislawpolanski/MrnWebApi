using MrnWebApi.Common.Models;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        Task<RailwayUnitDTO> GetRailwayUnitByStationAsync(StationDTO station);
    }
}
