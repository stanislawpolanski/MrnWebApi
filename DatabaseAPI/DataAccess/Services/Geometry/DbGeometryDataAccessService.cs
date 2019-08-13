using Microsoft.EntityFrameworkCore;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.Geometry
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

        public async Task<GeometryDTO> GetFirstGeometryByStationIdAsync(int id)
        {
            return await context
                .StationsToGeometries
                .Where(relation => relation.StationId.Equals(id))
                .Include(relation => relation.Geometry)
                //todo to be replaced by dto builder
                .Select(entity =>
                    new GeometryDTO()
                    {
                        Id = entity.Geometry.Id,
                        SerialisedSpatialData = entity.Geometry.SpatialData.ToString()
                    })
                .FirstOrDefaultAsync();
        }
    }
}
