using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Geometry
{
    public interface IGeometryDataAccessService
    {
        Task<GeometryDTO> GetFirstGeometryByStationIdAsync(int stationId);
        Task DeleteGeometriesByStationIdAsync(int stationId);
    }
}
