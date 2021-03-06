﻿using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Geometry
{
    public class DbGeometryDataAccessService :
        DbDataAccessAbstractService, IGeometryDataAccessService
    {
        public DbGeometryDataAccessService(MRN_developContext injectedContext)
            : base(injectedContext)
        {
        }

        public async Task DeleteGeometriesByStationIdAsync(int stationId)
        {
            IEnumerable<Geometries> geometriesToDelete =
                await getGeometriesToBeDeletedAsync(stationId);

            context.Geometries.RemoveRange(geometriesToDelete);
            await context.SaveChangesAsync();
        }

        private async Task<List<Geometries>>
            getGeometriesToBeDeletedAsync(int stationId)
        {
            Expression<Func<Geometries, bool>> geometryRelatedToStation =
                geometry =>
                    geometry
                    .StationsToGeometries
                    .Any(rel => rel.StationId.Equals(stationId));

            return await context
                .Geometries
                .Include(geometry => geometry.StationsToGeometries)
                .Where(geometryRelatedToStation)
                .ToListAsync();
        }

        public async Task<GeometryDTO>
            GetFirstGeometryByStationIdAsync(int queriedStationId)
        {
            Expression<Func<Geometries, bool>> geometryIsRelatedToStationById =
                geometry => geometry
                    .StationsToGeometries
                    .Any(stationToGeometry => stationToGeometry
                        .StationId
                        .Equals(queriedStationId));

            Expression<Func<Geometries, GeometryDTO>> entityToDTOSelector =
                entity => GeometryMapper.MapToDTO(entity);

            return await context
                .Geometries
                .Include(relationship => relationship.StationsToGeometries)
                .Where(geometryIsRelatedToStationById)
                .Select(entityToDTOSelector)
                .FirstOrDefaultAsync();
        }
    }
}
