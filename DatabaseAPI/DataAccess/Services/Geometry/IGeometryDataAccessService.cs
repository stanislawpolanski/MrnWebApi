using DatabaseAPI.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.Geometry
{
    public interface IGeometryDataAccessService
    {
        Task<GeometryDTO> GetFirstGeometryByStationIdAsync(int stationId);
        Task DeleteGeometriesByStationIdAsync(int stationId);
    }
}
