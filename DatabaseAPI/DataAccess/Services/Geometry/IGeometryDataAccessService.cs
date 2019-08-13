using MrnWebApi.Common.DTOs;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Geometry
{
    public interface IGeometryDataAccessService
    {
        Task<GeometryDTO> GetFirstGeometryByStationIdAsync(int stationId);
        Task DeleteGeometriesByStationIdAsync(int stationId);
    }
}
