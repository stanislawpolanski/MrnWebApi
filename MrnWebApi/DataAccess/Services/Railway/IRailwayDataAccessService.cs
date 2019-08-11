using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Railway
{
    public interface IRailwayDataAccessService
    {
        Task<IEnumerable<RailwayDTO>> GetRailwaysByStationIdAsync(int stationId);
    }
}
