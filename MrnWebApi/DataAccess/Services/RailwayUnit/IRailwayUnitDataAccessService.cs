using GeoAPI.Geometries;
using MrnWebApi.Common.Models;
namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public interface IRailwayUnitDataAccessService
    {
        RailwayUnitModel GetRailwayUnitByStation(StationModel station);
    }
}
