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
        GeometryModel GetFirstGeometryByStationId(int id);
    }
}
