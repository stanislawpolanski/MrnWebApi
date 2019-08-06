using GeoAPI.Geometries;
using MrnWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Geometry
{
    public interface IGeometryDataAccessService
    {
        Task<GeometryModel> GetFirstGeometryByStationIdAsync(int stationId);
        Task DeleteGeometriesByStationIdAsync(int stationId);
    }
}
