using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.Railway
{
    public interface IRailwayDataAccessService
    {
        IEnumerable<RailwayModel> GetRailwaysByStationId(int stationId);
    }
}
