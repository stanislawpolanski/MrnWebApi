﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;

namespace MrnWebApi.DataAccess.Services.Geometry
{
    public class DbGeometryDataAccessService : DbDataAccessAbstractService, IGeometryDataAccessService
    {
        public DbGeometryDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public GeometryModel GetFirstGeometryByStationId(int id)
        {
            return context
                .StationsToGeometries
                .Where(relation => relation.StationId.Equals(id))
                .Include(relation => relation.Geometry)
                .Select(entity =>
                    new GeometryModel()
                    {
                        Id = entity.Geometry.Id,
                        SerialisedSpatialData = entity.Geometry.SpatialData.ToString()
                    })
                .First();
        }
    }
}
