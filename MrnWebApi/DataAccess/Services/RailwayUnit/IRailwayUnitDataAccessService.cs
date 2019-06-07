using MrnWebApi.Common.Models;
namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        RailwayUnitModel GetRailwayUnitByStationId(int stationId);
    }
}
